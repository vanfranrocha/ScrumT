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
            HomeList = _HomeRep.Listaqt(new HomeMapper(), "Select (Select count(ID_TestUnidade)  from Teste_Unidade) as 'totaltestes', (Select count(ID_Projeto) from Projeto) as 'totalprojeto', (Select count(ID_PBacklog) from Product_Backlog) as 'totalhistorias'");
            Session["Lista"] = HomeList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(HomeList);
        }

    }
}