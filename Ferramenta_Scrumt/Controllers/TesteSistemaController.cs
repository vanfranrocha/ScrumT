using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    
    public class TesteSistemaController : Controller
    {
        List<TesteUnidade> TesteUnidadeList;
        List<TesteSistema> TesteSistemaList;
        List<TestIntegracao> TesteIntegracaoList;
        List<Users> UserList;
        TesteIntegracaoRepositorio _TesteRep = new TesteIntegracaoRepositorio();
        TesteUnidadeRepositorio _TesteUnRep = new TesteUnidadeRepositorio();
        TesteSistemaRepositorio _TesteSistemaRep = new TesteSistemaRepositorio();
        UsersRepositorio _UserRep = new UsersRepositorio();

        // GET: TesteSistema
        private void CarregaLista()
        {
            TesteSistemaList = _TesteSistemaRep.Lista(new TesteSistemaMapper());
            Session["Lista"] = TesteSistemaList;
            TesteUnidadeList = _TesteUnRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TesteUnidadeList, "Status", "Historia", "Classe");
            TesteIntegracaoList = _TesteRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TesteIntegracaoList, "Status", "Historia", "Versao");
            TesteSistemaList = _TesteSistemaRep.Listatest(new TesteSistemaMapper());
            ViewBag.testsis = new MultiSelectList(TesteSistemaList, "Status", "Falhas", "Versao");
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
    }
}