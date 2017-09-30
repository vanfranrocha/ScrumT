using System.Collections.Generic;
using Ferramenta_Scrumt.MODEL;
using System.Web.Mvc;
using System.Linq;
using Ferramenta_Scrumt.REPOSITORIO;
using APOIO_ITPAC.REPOSITORIO;

namespace Ferramenta_Scrumt.Controllers
{
    public class LoginController : Controller
    {
        List<Users> LogList;
        EquipeRepositorio _EqRep = new EquipeRepositorio();
        LoginRepositorio _LogRep = new LoginRepositorio();
        List<TesteUnidade> TestList;
        List<Calendar> CalendarList2;
        CalendarRepositorio _CalendarRep = new CalendarRepositorio();
        TesteUnidadeRepositorio _TestRep = new TesteUnidadeRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();
        List<TesteSistema> TestSisList;
        TesteSistemaRepositorio _TestSisRep = new TesteSistemaRepositorio();
        List<TesteAceitacao> TestAceiList;
        TesteAceitacaoRepositorio _TestAceiRep = new TesteAceitacaoRepositorio();

        private void CarregaLista()
        {
            LogList = _LogRep.Lista(new LoginMapper());
            Session["Lista"] = LogList;
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");
            TestSisList = _TestSisRep.Listatest(new TesteSistemaMapper());
            ViewBag.testsis = new MultiSelectList(TestSisList, "Status", "Falhas", "Versao");
            TestAceiList = _TestAceiRep.Listatest(new TesteAceitacaoMapper());
            ViewBag.testacei = new MultiSelectList(TestAceiList, "Membro", "Stakeholders", "Data");
            CalendarList2 = _CalendarRep.Lista(new CalendarMapper());
            ViewBag.qtdhistoriasc = new MultiSelectList(CalendarList2, "Historia");

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users L, string returnUrl)
        {
            CarregaLista();

            if (_LogRep.Login(L))
            {
                L = _LogRep.Lista(new LoginMapper()).Where(X => X.Email == L.Email).First();
                System.Web.Security.FormsAuthentication.SetAuthCookie(L.Email, false);
                Session["Usuario"] = L;
                Session["nomeUsuarioLogado"] = L.Nome;
                Session["Funcao"] = L.Nome_Funcao;
                Session["Email"] = L.Email;
                Session["Equipes"] = _EqRep.Lista(new EquipeMapper(), L.ID).ToList();

                return Redirect(returnUrl);
            }
            this.ModelState.AddModelError("", "Email ou Senha incorretos");
            return View();
        }
        public ActionResult LogOff()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View();
        }
        public new ActionResult Profile()
        {
            CarregaLista();
            return View();
        }
    }
}