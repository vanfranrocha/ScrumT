using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
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
    }
}