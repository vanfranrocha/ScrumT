using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class TestUnidadeController : Controller
    {
        // GET: Equipe
        List<TesteUnidade> TesteUnidadeList;
        List<ProductBacklog> ProductList;
        List<Users> UserList;
        TesteUnidadeRepositorio _TesteRep = new TesteUnidadeRepositorio();
        ProductBacklogRepositorio _ProductRep = new ProductBacklogRepositorio();
        UsersRepositorio _UserRep = new UsersRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();
        List<TesteSistema> TestSisList;
        TesteSistemaRepositorio _TestSisRep = new TesteSistemaRepositorio();

        private void CarregaLista()
        {
            TesteUnidadeList = _TesteRep.Lista(new TesteUnidadeMapper());
            Session["Lista"] = TesteUnidadeList;
            TesteUnidadeList = _TesteRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TesteUnidadeList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");
            TestSisList = _TestSisRep.Listatest(new TesteSistemaMapper());
            ViewBag.testsis = new MultiSelectList(TestSisList, "Status", "Falhas", "Versao");

        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(TesteUnidadeList);
        }
        [HttpPost]
        public ActionResult Create(TesteUnidade T)
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
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(TesteUnidadeList.Where(X => X.ID == id).First());
        }
        [HttpPost]
        public ActionResult Delete(TesteUnidade T)
        {
            CarregaLista();
            _TesteRep.Delete(TesteUnidadeList.Where(X => X.ID == T.ID).First());
            return RedirectToAction("Index");
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

            ViewBag.Statusu = new List<SelectListItem>
            {
                new SelectListItem{Text = "33", Value = "33"},
                new SelectListItem{Text = "66", Value = "66"},
                new SelectListItem{Text = "100", Value = "100"}
            };
            //passando uma model P
            TesteUnidade T = TesteUnidadeList.Where(X => X.ID == id).First();
            
            CarregaLista();
            return View(T);
        }
        [HttpPost]
        public ActionResult Edit(TesteUnidade T)
        {
            //carrega lista e traz um objeto da lista para ser editado

            _TesteRep.Update(T);
            CarregaLista();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {

            CarregaLista();
            return View(TesteUnidadeList.Where(X => X.ID == id).First());
        }
    }
}