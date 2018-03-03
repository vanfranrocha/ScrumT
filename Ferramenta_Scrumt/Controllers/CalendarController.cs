using Ferramenta_Scrumt.FILTERS;
using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    [Filterlisttest]
    public class CalendarController : Controller
    {
        // GET: Calendar

        List<Calendar> CalendarList;
        List<Calendar> CalendarList2;
        CalendarRepositorio _CalendarRep = new CalendarRepositorio();

        public ActionResult Index()
        {
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