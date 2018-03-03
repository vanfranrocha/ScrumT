using Ferramenta_Scrumt.FILTERS;
using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    [Filterlisttest]
    public class FluxoController : Controller
    {
        // GET: Fluxo
        
        ProductBacklogRepositorio _ProductRep = new ProductBacklogRepositorio();
        UsersRepositorio _UserRep = new UsersRepositorio();

        private void CarregaLista()
        {

        }
        public ActionResult Index()
        {
            CarregaLista();
            return View();
        }
    }
}