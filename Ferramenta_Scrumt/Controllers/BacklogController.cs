using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class BacklogController : Controller
    {
        // GET: Equipe
        List<ProductBacklog> PBacklogList;
        List<Projeto> ProjetoList;
        ProductBacklogRepositorio _PBacklogRep = new ProductBacklogRepositorio();
        ProjetoRepositorio _ProjetoRep = new ProjetoRepositorio();

        private void CarregaLista()
        {
            PBacklogList = _PBacklogRep.Lista(new ProductBacklogMapper());
            Session["Lista"] = PBacklogList;
        }

        public ActionResult Index()
        {
            CarregaLista();
            return View(PBacklogList);
        }
        [HttpPost]
        public ActionResult Create(ProductBacklog PB)
        {
            _PBacklogRep.ADD(PB);
            Session["Lista"] = PBacklogList;
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ProjetoList = _ProjetoRep.Lista(new ProjetoMapper());
            ViewBag.Descricao = new SelectList(ProjetoList, "ID", "Descricao");
            ViewBag.Importancia = new SelectList(new[]
            {
                new {Valor=1,Texto="Baixa"},
                new {Valor=2,Texto="Média"},
                new {Valor=3,Texto="Alta"}
            }, "Valor", "Texto");
            ViewBag.Aceito = new SelectList(new[]
            {
                new {Valor=1,Texto="Sim"},
                new {Valor=2,Texto="Não"}
            }, "Valor", "Texto");
            return View();
        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(PBacklogList.Where(X => X.ID == id).First());
        }
        [HttpPost]
        public ActionResult Delete(ProductBacklog PB)
        {
            CarregaLista();
            _PBacklogRep.Delete(PBacklogList.Where(X => X.ID == PB.ID).First());
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model A
            ProductBacklog A = PBacklogList.Where(X => X.ID == id).First();
            ProjetoList = _ProjetoRep.Lista(new ProjetoMapper());
            ViewBag.Descricao = new SelectList(ProjetoList, "ID", "Descricao");
            return View(A);
        }
        [HttpPost]
        public ActionResult Edit(ProductBacklog PB)
        {
            //carrega lista e traz um objeto da lista para ser editado
            CarregaLista();
            _PBacklogRep.Update(PB);
            Session["Lista"] = PBacklogList;
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            CarregaLista();
            return View(PBacklogList.Where(X => X.ID == id).First());
        }
    }
}