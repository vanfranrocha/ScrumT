using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        // GET: Calendar
        List<TesteUnidade> TestList;
        TesteUnidadeRepositorio _TestRep = new TesteUnidadeRepositorio();
        List<Calendar> CalendarList;
        List<Calendar> CalendarList2;
        CalendarRepositorio _CalendarRep = new CalendarRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();
        List<TesteSistema> TestSisList;
        TesteSistemaRepositorio _TestSisRep = new TesteSistemaRepositorio();
        List<TesteAceitacao> TestAceiList;
        TesteAceitacaoRepositorio _TestAceiRep = new TesteAceitacaoRepositorio();

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
            CalendarList2 = _CalendarRep.Lista(new CalendarMapper());
            ViewBag.qtdhistoriasc = new MultiSelectList(CalendarList2, "Historia");
            return View();
        }
        public JsonResult GetDados()
        {
            CalendarList = _CalendarRep.Lista(new CalendarMapper());
            return Json(CalendarList, JsonRequestBehavior.AllowGet);
        }


        
    }
}