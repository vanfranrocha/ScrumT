using Ferramenta_Scrumt.FILTERS;
using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    [Filterlisttest]
    public class GraficoController : Controller
    {
        List<Grafico> GraficoList;
        GraficoRepositorio _GraficoRep = new GraficoRepositorio();

        // GET: Grafico
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDados()
        {
            GraficoList = _GraficoRep.Lista(new GraficoMapper());
            return Json(GraficoList, JsonRequestBehavior.AllowGet);
        }

    }
}