using Ferramenta_Scrumt.FILTERS;
using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    [Filterlisttest]
    public class TesteIntegracaoController : Controller
    {

        // GET: TesteIntegracao
        List<TestIntegracao> TesteIntegracaoList;
        List<ProductBacklog> ProductList;
        List<Users> UserList;
        TesteIntegracaoRepositorio _TesteRep = new TesteIntegracaoRepositorio();
        ProductBacklogRepositorio _ProductRep = new ProductBacklogRepositorio();
        UsersRepositorio _UserRep = new UsersRepositorio();

        private void CarregaLista()
        {
            TesteIntegracaoList = _TesteRep.Lista(new TesteIntegracaoMapper());
            Session["Lista"] = TesteIntegracaoList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(TesteIntegracaoList);
        }
        [HttpPost]
        public ActionResult Create(TestIntegracao T)
        {
            _TesteRep.ADD(T);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            UserList = _UserRep.Lista(new UsersMapper());
            ViewBag.Nome = new SelectList(UserList, "ID", "Nome");
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];
            ProductList = _ProductRep.Lista(new ProductBacklogMapper(), Equipes);
            ViewBag.Historia = new SelectList(ProductList, "ID", "Historia");
            CarregaLista();

            ViewBag.Status = new List<SelectListItem>
            {
                new SelectListItem{Text = "33", Value = "33"},
                new SelectListItem{Text = "66", Value = "66"},
                new SelectListItem{Text = "100", Value = "100"}
            };
            return View();
        }
        public ActionResult Edit(int id)
        {
            CarregaLista();
            UserList = _UserRep.Lista(new UsersMapper());
            ViewBag.Nome = new SelectList(UserList, "ID", "Nome");
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];
            ProductList = _ProductRep.Lista(new ProductBacklogMapper(), Equipes);
            ViewBag.Historia = new SelectList(ProductList, "ID", "Historia");
            CarregaLista();

            ViewBag.Statuss = new List<SelectListItem>
            {
                new SelectListItem{Text = "33", Value = "33"},
                new SelectListItem{Text = "66", Value = "66"},
                new SelectListItem{Text = "100", Value = "100"}
            };
            //passando uma model P
            TestIntegracao T = TesteIntegracaoList.Where(X => X.ID == id).First();

            CarregaLista();
            return View(T);
        }
        [HttpPost]
        public ActionResult Edit(TestIntegracao T)
        {
            //carrega lista e traz um objeto da lista para ser editado

            _TesteRep.Update(T);
            CarregaLista();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(TesteIntegracaoList.Where(X => X.ID == id).First());
        }
        [HttpPost]
        public ActionResult Delete(TesteUnidade T)
        {
            CarregaLista();
            _TesteRep.Delete(TesteIntegracaoList.Where(X => X.ID == T.ID).First());
            return RedirectToAction("Index");
        }
    }
}