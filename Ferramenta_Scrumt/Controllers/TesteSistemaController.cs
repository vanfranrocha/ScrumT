using Ferramenta_Scrumt.FILTERS;
using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Filterlisttest]
    [Authorize]
    public class TesteSistemaController : Controller
    {
       
        List<TesteSistema> TesteSistemaList;
        List<Users> UserList;
        TesteSistemaRepositorio _TesteSistemaRep = new TesteSistemaRepositorio();
        UsersRepositorio _UserRep = new UsersRepositorio();

        // GET: TesteSistema
        private void CarregaLista()
        {
            TesteSistemaList = _TesteSistemaRep.Lista(new TesteSistemaMapper());
            Session["Lista"] = TesteSistemaList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(TesteSistemaList);
        }
        [HttpPost]
        public ActionResult Create(TesteSistema  T)
        {
            _TesteSistemaRep.ADD(T);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            UserList = _UserRep.Lista(new UsersMapper());
            ViewBag.Nome = new SelectList(UserList, "ID", "Nome");
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];

            CarregaLista();

            ViewBag.Statuss = new List<SelectListItem>
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

            CarregaLista();

            ViewBag.Statusu = new List<SelectListItem>
            {
                new SelectListItem{Text = "33", Value = "33"},
                new SelectListItem{Text = "66", Value = "66"},
                new SelectListItem{Text = "100", Value = "100"}
            };
            //passando uma model P
            TesteSistema T = TesteSistemaList.Where(X => X.ID == id).First();

            CarregaLista();
            return View(T);
        }
        [HttpPost]
        public ActionResult Edit(TesteSistema T)
        {
            //carrega lista e traz um objeto da lista para ser editado

            _TesteSistemaRep.Update(T);
            CarregaLista();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(TesteSistemaList.Where(X => X.ID == id).First());
        }
        [HttpPost]
        public ActionResult Delete(TesteSistema T)
        {
            CarregaLista();
            _TesteSistemaRep.Delete(TesteSistemaList.Where(X => X.ID == T.ID).First());
            return RedirectToAction("Index");
        }
    }
}