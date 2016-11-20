using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class ReleaseBacklogController : Controller
    {
        // GET: ReleaseBacklog
        List<ReleaseBacklog> RBacklogList;
        ReleaseBacklogRepositorio _RBacklogRep = new ReleaseBacklogRepositorio();
        private void CarregaLista()
        {
            RBacklogList = _RBacklogRep.Lista(new ReleaseBacklogMapper());
            Session["Lista"] = RBacklogList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(RBacklogList);
        }
    }
}