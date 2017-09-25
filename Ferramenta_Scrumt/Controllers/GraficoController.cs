using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class GraficoController : Controller
    {
        List<TesteUnidade> TestList;
        TesteUnidadeRepositorio _TestRep = new TesteUnidadeRepositorio();
        List<Grafico> GraficoList;
        GraficoRepositorio _GraficoRep = new GraficoRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();
        List<TesteSistema> TestSisList;
        TesteSistemaRepositorio _TestSisRep = new TesteSistemaRepositorio();
        List<TesteAceitacao> TestAceiList;
        TesteAceitacaoRepositorio _TestAceiRep = new TesteAceitacaoRepositorio();

        // GET: Grafico
        public ActionResult Index()
        {
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");
            TestSisList = _TestSisRep.Listatest(new TesteSistemaMapper());
            ViewBag.testsis = new MultiSelectList(TestSisList, "Status", "Falhas", "Versao");
            TestAceiList = _TestAceiRep.Listatest(new TesteAceitacaoMapper());
            ViewBag.testacei = new MultiSelectList(TestAceiList, "Membro", "Stakeholders", "Data");

            return View();
        }
        public JsonResult GetDados()
        {
            GraficoList = _GraficoRep.Lista(new GraficoMapper());
            return Json(GraficoList, JsonRequestBehavior.AllowGet);
        }
    }
}