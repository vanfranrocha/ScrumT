using Ferramenta_Scrumt.MODEL;
using System;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class TesteAceitacaoMapper : SqlMapperBase<TesteAceitacao>
    {
        public override TesteAceitacao MapFromSource(DataRow Record)
        {
            TesteAceitacao testacei = new TesteAceitacao();

            testacei.ID = (int)Record["ID_TesteAceitacao"];
            testacei.Membro = (string)Record["Nome"];
            testacei.ID_Membro = (int)Record["ID_Membro"];
            testacei.Data = (DateTime)Record["Data_Teste"];
            testacei.Massa_Dados = (string)Record["Massa_Dados"];
            testacei.Relatorio_F = (string)Record["Relatorio_Final"];
            testacei.Stakeholders = (string)Record["Stakeholders"];
            return testacei;
        }
    }
}