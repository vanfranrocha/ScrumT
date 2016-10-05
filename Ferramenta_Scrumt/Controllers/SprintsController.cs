using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    public class SprintsController : Controller
    {
        // GET: Sprints
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListSprints()
        {
            return View();
        }
    }
}