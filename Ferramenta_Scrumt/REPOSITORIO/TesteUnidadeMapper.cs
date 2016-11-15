using Ferramenta_Scrumt.MODEL;
using System;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class TesteUnidadeMapper : SqlMapperBase<TesteUnidade>
    {
        public override TesteUnidade MapFromSource(DataRow Record)
        {
            TesteUnidade testun = new TesteUnidade();

            testun.ID = (int)Record["ID_TestUnidade"];
            testun.Historia = (string)Record["Historia"];
            testun.ID_Backlog = (int)Record["ID_Backlog"];
            testun.Membro = (string)Record["Nome"];
            testun.ID_Membro = (int)Record["ID_Membro"];
            testun.Classe = (String)Record["Classe"];
            testun.Status = (String)Record["Status"];
            return testun;
        }
    }
}