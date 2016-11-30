using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    
    public class TesteSistemaController : Controller
    {
        List<TesteUnidade> TesteUnidadeList;
        List<TesteSistema> TesteSistemaList;
        List<TestIntegracao> TesteIntegracaoList;
        List<Users> UserList;
        TesteIntegracaoRepositorio _TesteRep = new TesteIntegracaoRepositorio();
        TesteUnidadeRepositorio _TesteUnRep = new TesteUnidadeRepositorio();
        TesteSistemaRepositorio _TesteSistemaRep = new TesteSistemaRepositorio();
        UsersRepositorio _UserRep = new UsersRepositorio();
        // GET: TesteSistema
         private void CarregaLista()
        {
            TesteSistemaList = _TesteSistemaRep.Lista(new TesteSistemaMapper());
            Session["Lista"] = TesteSistemaList;
            TesteUnidadeList = _TesteUnRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TesteUnidadeList, "Status", "Historia", "Classe");
            TesteIntegracaoList = _TesteRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TesteIntegracaoList, "Status", "Historia", "Versao");
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(TesteSistemaList);
        }
    }
}