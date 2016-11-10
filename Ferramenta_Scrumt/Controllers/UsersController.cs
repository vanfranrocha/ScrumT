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
        List<Users> EquipeList;
        UsersRepositorio _EquipeRep = new UsersRepositorio();

        private void CarregaLista()
        {

            EquipeList = _EquipeRep.Lista(new UsersMapper());
            Session["Lista"] = EquipeList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(EquipeList);
        }
        [HttpPost]
        public ActionResult Create(Users E)
        {
            _EquipeRep.ADD(E);
            Session["Lista"] = EquipeList;
            return RedirectToAction("Index");
        }
        
        public ActionResult Create()
        {
            CarregaLista();
            return View();
        }
      
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View((Users)EquipeList.Where(X => X.ID == id).First());
        }

        [HttpPost]
        public ActionResult Delete(Users E)
        {
            CarregaLista();

            _EquipeRep.Delete(EquipeList.Where(X => X.ID == E.ID).First());
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model E
            Users E = EquipeList.Where(X => X.ID == id).First();
            return View(E);
        }
        [HttpPost]
        public ActionResult Edit(Users E)
        {
            //carrega lista e traz um objeto da lista para ser editado
            CarregaLista();
            _EquipeRep.Update(E);
            Session["Lista"] = EquipeList;
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {  
            CarregaLista();
            return View(EquipeList.Where(X => X.ID == id).First());
        }
       
    }
}