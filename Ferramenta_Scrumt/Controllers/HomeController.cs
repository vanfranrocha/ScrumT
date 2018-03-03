using Ferramenta_Scrumt.FILTERS;
using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    [Filterlisttest]
    public class HomeController : Controller
    {
        List<Home> HomeList;
        HomeRepositorio _HomeRep = new HomeRepositorio();

        private void CarregaLista()
        {
            HomeList = _HomeRep.Listaqt(new HomeMapper(), "Select (select top 1 ((select count(ID_TesteIntegracao) from Teste_Integracao) + (select count(ID_TestUnidade) from Teste_Unidade)+ (select count(ID_TesteSistema) from Teste_Sistema) +(select count(ID_TesteAceitacao) from Teste_Aceitacao)) from Teste_Integracao) as 'totaltestes', (Select count(ID_Projeto) from Projeto) as 'totalprojeto', (Select count(ID_PBacklog) from Product_Backlog) as 'totalhistorias'");
            Session["Lista"] = HomeList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(HomeList);
        }

    }
}