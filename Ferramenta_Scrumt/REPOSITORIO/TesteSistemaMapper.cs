using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class TesteSistemaMapper : SqlMapperBase<TesteSistema>
    {
        public override TesteSistema MapFromSource(DataRow Record)
        {
            TesteSistema testsis = new TesteSistema();

            testsis.ID = (int)Record["ID_TesteIntegracao"];
            testsis.Membro = (string)Record["Nome"];
            testsis.ID_Membro = (int)Record["ID_Membro"];
            testsis.Data_Teste = (DateTime)Record["Data_Teste"];
            testsis.Versao = (string)Record["Versao_Testada"];
            testsis.Relatorio = (string)Record["Relatorio_Log"];
            testsis.Massa_Dados = (string)Record["Massa_Dados"];
            testsis.Falhas = (string)Record["Falhas"];
            testsis.Status = (string)Record["Status"];
            return testsis;
        }
    }
}