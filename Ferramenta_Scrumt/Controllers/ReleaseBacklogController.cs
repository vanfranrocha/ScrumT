using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class ReleaseBacklogController : Controller
    {
        // GET: ReleaseBacklog
        List<ReleaseBacklog> RBacklogList;
        ReleaseBacklogRepositorio _RBacklogRep = new ReleaseBacklogRepositorio();
        List<TesteUnidade> TestList;
        TesteUnidadeRepositorio _TestRep = new TesteUnidadeRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();
        List<ProductBacklog> ProductList;
        ProductBacklogRepositorio _ProductRep = new ProductBacklogRepositorio();
        List<Users> UserList;
        UsersRepositorio _UserRep = new UsersRepositorio();

        private void CarregaLista()
        {
            RBacklogList = _RBacklogRep.Lista(new ReleaseBacklogMapper());
            Session["Lista"] = RBacklogList;
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(RBacklogList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CarregaLista();
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];

            ViewBag.Situacao = new List<SelectListItem>
            {
                new SelectListItem{Text = "A Fazer", Value = "A Fazer"},
                new SelectListItem{Text = "Em Execução", Value = "Em Execução"},
                new SelectListItem{Text = "Em Teste", Value = "Em Teste"},
                new SelectListItem{Text = "Done", Value = "Done"}
            };
            return View();
        }
        [HttpPost]
        public ActionResult Create(ReleaseBacklog RB)
        {
            _RBacklogRep.ADD(RB);
            Session["Lista"] = RBacklogList;
            CarregaLista();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(RBacklogList.Where(X => X.ID == id).First());
        }
        [HttpPost]
        public ActionResult Delete(ReleaseBacklog RB)
        {
            CarregaLista();
            _RBacklogRep.Delete(RBacklogList.Where(X => X.ID == RB.ID).First());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model A
            ReleaseBacklog A = RBacklogList.Where(X => X.ID == id).First();
            List<Equipe> Equipes = (List<Equipe>)Session["Equipes"];
            ProductList = _ProductRep.Lista(new ProductBacklogMapper());
            ViewBag.Historia = new SelectList(ProductList, "ID", "Historia");

            UserList = _UserRep.Lista(new UsersMapper());
            ViewBag.Nome = new SelectList(UserList, "ID", "Nome");

            ViewBag.Situacao = new List<SelectListItem>
            {
                new SelectListItem{Text = "A Fazer", Value = "A Fazer"},
                new SelectListItem{Text = "Em Execução", Value = "Em Execução"},
                new SelectListItem{Text = "Em Teste", Value = "Em Teste"},
                new SelectListItem{Text = "Done", Value = "Done"}
            };
            return View(A);
        }

        [HttpPost]
        public ActionResult Edit(ReleaseBacklog RB)
        {
            //carrega lista e traz um objeto da lista para ser editado
            CarregaLista();
            _RBacklogRep.Update(RB);
            Session["Lista"] = RBacklogList;
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            CarregaLista();
            return View(RBacklogList.Where(X => X.ID == id).First());
        }
    }
}