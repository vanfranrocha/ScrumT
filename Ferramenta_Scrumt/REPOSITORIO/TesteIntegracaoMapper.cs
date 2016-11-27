using Ferramenta_Scrumt.MODEL;
using System;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class TesteIntegracaoMapper : SqlMapperBase<TestIntegracao>
    {
        public override TestIntegracao MapFromSource(DataRow Record)
        {
            TestIntegracao testint = new TestIntegracao();

            testint.ID = (int)Record["ID_TesteIntegracao"];
            testint.Historia = (string)Record["Historia"];
            testint.ID_Backlog = (int)Record["ID_PBacklog"];
            testint.Membro = (string)Record["Nome"];
            testint.ID_Membro = (int)Record["ID_Membro"];
            testint.Data_Teste = (DateTime)Record["Data_Teste"];
            testint.Versao = (string)Record["Versao_Testada"];
            testint.Rel_Log = (string)Record["Relatorio_Log"];
            testint.Erros = (string)Record["Erros"];
            testint.Status = (string)Record["Status"];
            return testint;
        }
    }
}