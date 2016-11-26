using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class QuadrotarefasController : Controller
    {
        // GET: Quadrotarefas
        List<Quadro_tarefas> QtarefasList;
        QuadrotarefasRepositorio _QtarefasRep = new QuadrotarefasRepositorio();
        List<Projeto> ProjetoList;
        ProjetoRepositorio _ProjetoRep = new ProjetoRepositorio();
        List<TesteUnidade> TestList;
        TesteUnidadeRepositorio _TestRep = new TesteUnidadeRepositorio();

        private void CarregaLista()
        {
            QtarefasList = _QtarefasRep.Listaquadro(new QuadrotarefasMapper(), "Select [Product_Backlog].[Historia],[Projeto].[Descricao],[Product_Release].[ID_PBacklog],[Situacao_Quadrotarefas], [Product_Backlog].[Importancia] from Product_Release Inner Join Product_Backlog on Product_Release.ID_PBacklog = Product_Backlog.ID_PBacklog Inner Join Projeto on Product_Backlog.ID_Projeto = Projeto.ID_Projeto group by Historia,Descricao, Product_Backlog.ID_PBacklog, Product_Release.ID_PBacklog, Situacao_QuadroTarefas, Importancia");
            Session["Lista"] = QtarefasList;
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
        }
        public ActionResult Index()
        {
            CarregaLista();
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];
            ProjetoList = _ProjetoRep.Lista(new ProjetoMapper(),Equipes);
            ViewBag.Projeto = new SelectList(ProjetoList, "ID", "Descricao");
            return View(QtarefasList);
        }
    }
}