using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using LOGIN.REPOSITORIO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    public class RegistrationController : Controller
    {
        List<Users> EquipeList;
        RegistrationRepositorio _EquipeRep = new RegistrationRepositorio();
        LoginRepositorio _LogRep = new LoginRepositorio();

        private void CarregaLista()
        {
            EquipeList = _EquipeRep.Lista2(new RegistrationMapper());
            Session["Lista"] = EquipeList;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Users E)
        {
            if (_EquipeRep.Registro(E))
            {
                E = _EquipeRep.Lista2(new LoginMapper()).Where(X => X.Email == E.Email).First();
                System.Web.Security.FormsAuthentication.SetAuthCookie(E.Email, false);
                this.ModelState.AddModelError("", "Email já cadastrado");
                return View();
            }
            else
            {
                _EquipeRep.ADD(E);
                return Redirect("/Login/Login");
              
            }
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(EquipeList);
        }
    }
}