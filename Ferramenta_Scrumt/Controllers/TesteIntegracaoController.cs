using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class TesteIntegracaoController : Controller
    {

        // GET: TesteIntegracao
        List<TesteUnidade> TesteUnidadeList;
        List<TestIntegracao> TesteIntegracaoList;
        TesteIntegracaoRepositorio _TesteRep = new TesteIntegracaoRepositorio();
        TesteUnidadeRepositorio _TesteUnRep = new TesteUnidadeRepositorio();
        private void CarregaLista()
        {
            TesteIntegracaoList = _TesteRep.Lista(new TesteIntegracaoMapper());
            Session["Lista"] = TesteIntegracaoList;
            TesteUnidadeList = _TesteUnRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TesteUnidadeList, "Status", "Historia", "Classe");
            TesteIntegracaoList = _TesteRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TesteIntegracaoList, "Status", "Historia", "Versao");
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(TesteIntegracaoList);
        }
    }
}