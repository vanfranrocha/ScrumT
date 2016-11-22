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
    public class EquipeController : Controller
    {
        
        List<Users> UsersList;
        List<Equipe> EquiList;
        EquipeRepositorio _EquiRep = new EquipeRepositorio();
        UsersRepositorio _UsersRep = new UsersRepositorio();
        List<TesteUnidade> TestList;
        TesteUnidadeRepositorio _TestRep = new TesteUnidadeRepositorio();
        private void CarregaLista()
        {
            EquiList = _EquiRep.Lista(new EquipeMapper());
            Session["Lista"] = EquiList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            return View(EquiList);
        }
        [HttpPost]
        public ActionResult Create(Equipe E)
        {
            _EquiRep.ADD(E);
            Session["Lista"] = EquiList;
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            CarregaLista();
            UsersList = _UsersRep.Lista(new UsersMapper());
            ViewBag.Membro = new SelectList(UsersList, "ID", "Nome");
            return View();
        }

    }
}