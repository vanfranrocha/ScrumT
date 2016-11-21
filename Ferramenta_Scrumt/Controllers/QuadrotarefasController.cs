using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class QuadrotarefasController : Controller
    {
        // GET: Quadrotarefas
        public ActionResult Index()
        {
            return View();
        }
    }
}