using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class ProjetoController : Controller
    {
        // GET: Projeto
        List<Projeto> ProjetoList;
        ProjetoRepositorio _ProjetoRep = new ProjetoRepositorio();
        private void CarregaLista()
        {
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];

            ProjetoList = _ProjetoRep.Lista(new ProjetoMapper(),Equipes);
            Session["Lista"] = ProjetoList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(ProjetoList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Projeto P)
        {
            CarregaLista();
            _ProjetoRep.ADD(P);
            Session["Lista"] = ProjetoList;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(ProjetoList.Where(X => X.ID == id).First());
        }
        [HttpPost]
        public ActionResult Delete(Projeto P)
        {
            CarregaLista();
            _ProjetoRep.Delete(ProjetoList.Where(X => X.ID == P.ID).First());
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model P
            Projeto P = ProjetoList.Where(X => X.ID == id).First();
            CarregaLista();
            return View(P);
        }
        [HttpPost]
        public ActionResult Edit(Projeto P)
        {
            //carrega lista e traz um objeto da lista para ser editado

            _ProjetoRep.Update(P);
            CarregaLista();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            CarregaLista();
            return View(ProjetoList.Where(X => X.ID == id).First());
        }
    }
}