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
        List<ProductBacklog> PBacklogList;
        List<Projeto> ProjetoList;
        ProductBacklogRepositorio _PBacklogRep = new ProductBacklogRepositorio();
        ProjetoRepositorio _ProjetoRep = new ProjetoRepositorio();
        List<TesteUnidade> TestList;
        TesteUnidadeRepositorio _TestRep = new TesteUnidadeRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();

        private void CarregaLista()
        {
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];

            PBacklogList = _PBacklogRep.Lista(new ProductBacklogMapper(), Equipes);
            Session["Lista"] = PBacklogList;
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");

        }

        public ActionResult Index()
        {
            CarregaLista();
            return View(PBacklogList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CarregaLista();
            ProjetoList = _ProjetoRep.Lista(new ProjetoMapper());
            ViewBag.Descricao = new SelectList(ProjetoList, "ID", "Descricao");
            ViewBag.Importancia = new List<SelectListItem>
            {
                new SelectListItem{Text = "Baixa", Value = "Baixa"},
                new SelectListItem{Text = "Média", Value = "Média"},
                new SelectListItem{Text = "Alta", Value = "Alta"}
            };

            ViewBag.Aceito = new List<SelectListItem> {
                 new SelectListItem { Text = "Não", Value = "Não"},
                 new SelectListItem { Text = "Sim", Value = "Sim"}
             }; 
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductBacklog PB)
        {
            CarregaLista();
            _PBacklogRep.ADD(PB);
            PB.ID = PBacklogList.Count == 0 ? 0 : PBacklogList.Last().ID + 1;
            Session["Lista"] = PBacklogList;
            return RedirectToAction("Index");
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model A
            ProductBacklog A = PBacklogList.Where(X => X.ID == id).First();
            ProjetoList = _ProjetoRep.Lista(new ProjetoMapper());
            ViewBag.Descricao = new SelectList(ProjetoList, "ID", "Descricao");

            ViewBag.Importancia = new List<SelectListItem>
            {
                new SelectListItem{Text = "Baixa", Value = "Baixa"},
                new SelectListItem{Text = "Média", Value = "Média"},
                new SelectListItem{Text = "Alta", Value = "Alta"}
            };

            ViewBag.Aceito = new List<SelectListItem> {
                 new SelectListItem { Text = "Não", Value = "Não"},
                 new SelectListItem { Text = "Sim", Value = "Sim"}
             };
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