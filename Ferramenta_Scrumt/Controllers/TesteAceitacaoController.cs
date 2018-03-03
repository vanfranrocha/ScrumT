using Ferramenta_Scrumt.FILTERS;
using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    [Filterlisttest]
    public class TesteAceitacaoController : Controller
    {
        List<Users> UserList;
        ProductBacklogRepositorio _ProductRep = new ProductBacklogRepositorio();
        UsersRepositorio _UserRep = new UsersRepositorio();

        List<TesteAceitacao> TestAceiList;
        TesteAceitacaoRepositorio _TestAceiRep = new TesteAceitacaoRepositorio();
        // GET: TesteAceitacao
        private void CarregaLista()
        {
            TestAceiList = _TestAceiRep.Lista(new TesteAceitacaoMapper());
            Session["Lista"] = TestAceiList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(TestAceiList);
        }
        [HttpPost]
        public ActionResult Create(TesteAceitacao T)
        {
            _TestAceiRep.ADD(T);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            UserList = _UserRep.Lista(new UsersMapper());
            ViewBag.Nome = new SelectList(UserList, "ID", "Nome");
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];

            CarregaLista();
            return View();
        }
    }
}