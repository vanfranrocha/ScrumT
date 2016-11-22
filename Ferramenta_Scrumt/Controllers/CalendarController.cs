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
        List<ReleaseBacklog> RBacklogList;
        ReleaseBacklogRepositorio _RBacklogRep = new ReleaseBacklogRepositorio();

        public ActionResult Index()
        {
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            return View();
        }
        public JsonResult GetDados()
        {
            RBacklogList = _RBacklogRep.Lista(new ReleaseBacklogMapper());
            return Json(RBacklogList, JsonRequestBehavior.AllowGet);
        }


        
    }
}