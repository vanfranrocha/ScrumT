using Ferramenta_Scrumt.FILTERS;
using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    [Filterlisttest]
    public class QuadrotarefasController : Controller
    {
        // GET: Quadrotarefas
        List<Quadro_tarefas> QtarefasList;
        QuadrotarefasRepositorio _QtarefasRep = new QuadrotarefasRepositorio();
        List<Projeto> ProjetoList;
        ProjetoRepositorio _ProjetoRep = new ProjetoRepositorio();

        private void CarregaLista()
        {
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];
            QtarefasList = _QtarefasRep.Listaquadro(new QuadrotarefasMapper(), "Select [Product_Backlog].[Historia],[Projeto].ID_Projeto,[Projeto].[Descricao],[Product_Release].[ID_PBacklog],[Situacao_Quadrotarefas], [Product_Backlog].[Importancia] from Product_Release Inner Join Product_Backlog on Product_Release.ID_PBacklog = Product_Backlog.ID_PBacklog Inner Join Projeto on Product_Backlog.ID_Projeto = Projeto.ID_Projeto group by Historia,Descricao,Projeto.ID_Projeto, Product_Backlog.ID_PBacklog, Product_Release.ID_PBacklog, Situacao_QuadroTarefas, Importancia", Equipes);
            Session["Lista"] = QtarefasList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];
            ProjetoList = _ProjetoRep.Lista(new ProjetoMapper(),Equipes);
            ViewBag.Projeto = new SelectList(ProjetoList, "ID", "Descricao");
            return View(QtarefasList);
        }
        public ActionResult Details(int id)
        {
            CarregaLista();
            return View(QtarefasList.Where(X => X.id_Pbacklog == id).First());
        }
    }
}