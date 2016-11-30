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
        List<Projeto> ProjList;
        ProjetoRepositorio _ProjRep = new ProjetoRepositorio();
        List<TestIntegracao> TestIntList;
        TesteIntegracaoRepositorio _TestIntRep = new TesteIntegracaoRepositorio();
        List<TesteSistema> TestSisList;
        TesteSistemaRepositorio _TestSisRep = new TesteSistemaRepositorio();
        List<TesteAceitacao> TestAceiList;
        TesteAceitacaoRepositorio _TestAceiRep = new TesteAceitacaoRepositorio();

        private void CarregaLista()
        {
            EquiList = _EquiRep.Lista(new EquipeMapper());
            Session["Lista"] = EquiList;
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");
            TestSisList = _TestSisRep.Listatest(new TesteSistemaMapper());
            ViewBag.testsis = new MultiSelectList(TestSisList, "Status", "Falhas", "Versao");
            TestAceiList = _TestAceiRep.Listatest(new TesteAceitacaoMapper());
            ViewBag.testacei = new MultiSelectList(TestAceiList, "Membro", "Stakeholders", "Data");
        }
        public ActionResult Index()
        {
            CarregaLista();

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
            ProjList = _ProjRep.ListaProj(new ProjetoMapper(), "Select top 1 ID_Projeto,Descricao, Data_Inicio, Data_Fim from Projeto order by ID_Projeto desc");
            ViewBag.Projeto = new SelectList(ProjList, "ID", "Descricao");

            UsersList = _UsersRep.Lista(new UsersMapper());
            ViewBag.Nome_Membro = new SelectList(UsersList, "ID", "Nome");
            return View();
        }

    }
}