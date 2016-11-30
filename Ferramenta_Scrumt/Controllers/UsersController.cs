using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Equipe
        List<Users> UsersList;
        List<Funcao> FuncaoList;
        UsersRepositorio _UsersRep = new UsersRepositorio();
        FuncaoRepositorio _FunRep = new FuncaoRepositorio();
        List<TesteUnidade> TestList;
        TesteUnidadeRepositorio _TestRep = new TesteUnidadeRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();
        List<TesteSistema> TestSisList;
        TesteSistemaRepositorio _TestSisRep = new TesteSistemaRepositorio();

        private void CarregaLista()
        {

            UsersList = _UsersRep.Lista(new UsersMapper());
            Session["Lista"] = UsersList;
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");
            TestSisList = _TestSisRep.Listatest(new TesteSistemaMapper());
            ViewBag.testsis = new MultiSelectList(TestSisList, "Status", "Falhas", "Versao");

        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(UsersList);
        }
        [HttpPost]
        public ActionResult Create(Users E)
        {
            _UsersRep.ADD(E);
            Session["Lista"] = UsersList;
            CarregaLista();
            return RedirectToAction("Index");
        }
        
        public ActionResult Create()
        {
            CarregaLista();
            FuncaoList = _FunRep.Lista(new FuncaoMapper());
            ViewBag.Nome_Funcao = new SelectList(FuncaoList, "ID_Funcao", "Nome_Funcao");
            return View();
        }
      
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View((Users)UsersList.Where(X => X.ID == id).First());
        }

        [HttpPost]
        public ActionResult Delete(Users E)
        {
            CarregaLista();

            _UsersRep.Delete(UsersList.Where(X => X.ID == E.ID).First());
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model E

            Users E = UsersList.Where(X => X.ID == id).First();
            FuncaoList = _FunRep.Lista(new FuncaoMapper());
            ViewBag.Nome_Funcao = new SelectList(FuncaoList, "ID_Funcao", "Nome_Funcao");
            return View(E);
        }
        [HttpPost]
        public ActionResult Edit(Users E)
        {
            //carrega lista e traz um objeto da lista para ser editado
            CarregaLista();
            _UsersRep.Update(E);
            Session["Lista"] = UsersList;
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {  
            CarregaLista();
            return View(UsersList.Where(X => X.ID == id).First());
        }
       
    }
}