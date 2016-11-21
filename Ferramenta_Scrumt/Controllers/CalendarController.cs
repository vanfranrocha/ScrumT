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

        public ActionResult Index()
        {
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.Teste = new SelectList(TestList, "Status", "Historia");
            return View();
        }
    }
}