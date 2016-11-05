using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        private void CarregaLista()
        {
            TesteUnidadeList = _TesteRep.Lista(new TesteUnidadeMapper());
            Session["Lista"] = TesteUnidadeList;
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
            ViewBag.Nome = new SelectList(UserList, "ID_Equipe", "Nome");
            ProductList = _ProductRep.Lista(new ProductBacklogMapper());
            ViewBag.Historia = new SelectList(ProductList, "ID_PBacklog", "Historia");
            return View();
        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(TesteUnidadeList.Where(X => X.ID_TestUnidade == id).First());
        }
        [HttpPost]
        public ActionResult Delete(TesteUnidade T)
        {
            CarregaLista();
            _TesteRep.Delete(TesteUnidadeList.Where(X => X.ID_TestUnidade == T.ID_TestUnidade).First());
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model P
            TesteUnidade T = TesteUnidadeList.Where(X => X.ID_TestUnidade == id).First();
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
            return View(TesteUnidadeList.Where(X => X.ID_TestUnidade == id).First());
        }
    }
}