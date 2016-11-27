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
        CalendarRepositorio _CalendarRep = new CalendarRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();

        public ActionResult Index()
        {
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");
            return View();
        }
        public JsonResult GetDados()
        {
            CalendarList = _CalendarRep.Lista(new CalendarMapper());
            return Json(CalendarList, JsonRequestBehavior.AllowGet);
        }


        
    }
}