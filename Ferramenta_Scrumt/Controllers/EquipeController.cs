using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    public class EquipeController : Controller
    {
        // GET: Equipe
        List<Equipe> EquipeList;
        EquipeRepositorio _EquipeRep = new EquipeRepositorio();
        private void CarregaLista()
        {
            EquipeList = _EquipeRep.Lista(new EquipeMapper());
            Session["Lista"] = EquipeList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(EquipeList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Equipe E)
        {
            CarregaLista();
            _EquipeRep.ADD(E);
            E.ID_Equipe = EquipeList.Count == 0 ? 0 : EquipeList.Last().ID_Equipe + 1;
            Session["Lista"] = EquipeList;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(EquipeList.Where(X => X.ID_Equipe == id).First());
        }
        [HttpPost]
        public ActionResult Delete(Equipe E)
        {
            CarregaLista();
            _EquipeRep.Delete(EquipeList.Where(X => X.ID_Equipe == E.ID_Equipe).First());
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model P
            Equipe A = EquipeList.Where(X => X.ID_Equipe == id).First();
            CarregaLista();
            return View(A);
        }
        [HttpPost]
        public ActionResult Edit(Equipe E)
        {
            //carrega lista e traz um objeto da lista para ser editado

            _EquipeRep.Update(E);
            CarregaLista();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            CarregaLista();
            return View(EquipeList.Where(X => X.ID_Equipe == id).First());
        }
    }
}