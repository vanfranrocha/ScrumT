using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;

namespace Ferramenta_Scrumt.FILTERS
{
    public class Filterlisttest : ActionFilterAttribute, IActionFilter
    {
        List<ProductBacklog> PBacklogList;
        ProductBacklogRepositorio _PBacklogRep = new ProductBacklogRepositorio();
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

        public object ViewBag { get; private set; }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            PBacklogList = _PBacklogRep.Listahist(new ProductBacklogMapper());
            filterContext.Controller.ViewBag.Historia = new MultiSelectList(PBacklogList, "Importancia", "Historia", "Nome_Projeto");
            TestList = _TestRep.Listatest(new TesteUnidadeMapper());
            filterContext.Controller.ViewBag.tes = new MultiSelectList(TestList, "Status", "Historia", "Classe");
            TestIntList = _TestIntRep.Listatest(new TesteIntegracaoMapper());
            filterContext.Controller.ViewBag.testint = new MultiSelectList(TestIntList, "Status", "Historia", "Versao");
            TestSisList = _TestSisRep.Listatest(new TesteSistemaMapper());
            filterContext.Controller.ViewBag.testsis = new MultiSelectList(TestSisList, "Status", "Falhas", "Versao");
            TestAceiList = _TestAceiRep.Listatest(new TesteAceitacaoMapper());
            filterContext.Controller.ViewBag.testacei = new MultiSelectList(TestAceiList, "Membro", "Stakeholders", "Data");
            CalendarList2 = _CalendarRep.Lista(new CalendarMapper());
            filterContext.Controller.ViewBag.qtdhistoriasc = new MultiSelectList(CalendarList2, "Historia");

            this.OnActionExecuting(filterContext);
        }
    }
}