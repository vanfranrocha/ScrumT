using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class TesteAceitacaoController : Controller
    {
        List<TesteUnidade> TesteUnidadeList;
        List<Users> UserList;
        TesteUnidadeRepositorio _TesteRep = new TesteUnidadeRepositorio();
        ProductBacklogRepositorio _ProductRep = new ProductBacklogRepositorio();
        UsersRepositorio _UserRep = new UsersRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();
        List<TesteSistema> TestSisList;
        TesteSistemaRepositorio _TestSisRep = new TesteSistemaRepositorio();

        List<TesteAceitacao> TestAceiList;
        TesteAceitacaoRepositorio _TestAceiRep = new TesteAceitacaoRepositorio();
        // GET: TesteAceitacao
        private void CarregaLista()
        {
            TestAceiList = _TestAceiRep.Lista(new TesteAceitacaoMapper());
            Session["Lista"] = TestAceiList;
            TesteUnidadeList = _TesteRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TesteUnidadeList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");
            TestSisList = _TestSisRep.Listatest(new TesteSistemaMapper());
            ViewBag.testsis = new MultiSelectList(TestSisList, "Status", "Falhas", "Versao");
            TestAceiList = _TestAceiRep.Listatest(new TesteAceitacaoMapper());
            ViewBag.testacei = new MultiSelectList(TestAceiList, "Membro", "Stakeholders", "Data");

        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(TestAceiList);
        }
    }
}