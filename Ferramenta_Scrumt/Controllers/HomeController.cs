using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

    }
}