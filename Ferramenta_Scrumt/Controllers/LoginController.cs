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

        private void CarregaLista()
        {
            LogList = _LogRep.Lista(new LoginMapper());
            Session["Lista"] = LogList;
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
            return View();
        }
    }
}