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
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();
        List<TesteSistema> TestSisList;
        TesteSistemaRepositorio _TestSisRep = new TesteSistemaRepositorio();

        private void CarregaLista()
        {
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];
            QtarefasList = _QtarefasRep.Listaquadro(new QuadrotarefasMapper(), "Select [Product_Backlog].[Historia],[Projeto].ID_Projeto,[Projeto].[Descricao],[Product_Release].[ID_PBacklog],[Situacao_Quadrotarefas], [Product_Backlog].[Importancia] from Product_Release Inner Join Product_Backlog on Product_Release.ID_PBacklog = Product_Backlog.ID_PBacklog Inner Join Projeto on Product_Backlog.ID_Projeto = Projeto.ID_Projeto group by Historia,Descricao,Projeto.ID_Projeto, Product_Backlog.ID_PBacklog, Product_Release.ID_PBacklog, Situacao_QuadroTarefas, Importancia", Equipes);
            Session["Lista"] = QtarefasList;
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");
            TestSisList = _TestSisRep.Listatest(new TesteSistemaMapper());
            ViewBag.testsis = new MultiSelectList(TestSisList, "Status", "Falhas", "Versao");
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