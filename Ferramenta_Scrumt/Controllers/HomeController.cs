using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        List<Home> HomeList;
        HomeRepositorio _HomeRep = new HomeRepositorio();
        List<ProductBacklog> PBacklogList;
        ProductBacklogRepositorio _PBacklogRep = new ProductBacklogRepositorio();
        List<TesteUnidade> TestList;
        TesteUnidadeRepositorio _TestRep = new TesteUnidadeRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();

        private void CarregaLista()
        {
            
            PBacklogList = _PBacklogRep.Listahist(new ProductBacklogMapper());
            ViewBag.Historia = new MultiSelectList(PBacklogList, "Importancia", "Historia", "Nome_Projeto");
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");


            HomeList = _HomeRep.Listaqt(new HomeMapper(), "Select (select top 1 ((select count(ID_TesteIntegracao) from Teste_Integracao) + (select count(ID_TestUnidade) from Teste_Unidade)) from Teste_Integracao) as 'totaltestes', (Select count(ID_Projeto) from Projeto) as 'totalprojeto', (Select count(ID_PBacklog) from Product_Backlog) as 'totalhistorias'");
            Session["Lista"] = HomeList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(HomeList);
        }

    }
}