using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        List<Home> HomeList;
        HomeRepositorio _HomeRep = new HomeRepositorio();

        private void CarregaLista()
        {
            HomeList = _HomeRep.Listaqtprojetos(new HomeMapper(), "Select count(ID_Projeto) as 'totalprojeto' from Projeto");
            Session["Lista"] = HomeList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(HomeList);
        }

    }
}