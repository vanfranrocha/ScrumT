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