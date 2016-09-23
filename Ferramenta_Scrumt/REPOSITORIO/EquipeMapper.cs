using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ferramenta_Scrumt.MODEL;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class EquipeMapper : SqlMapperBase<Equipe>
        {
            public override Equipe MapFromSource(DataRow Record)
            {
                Equipe col = new Equipe();

                col.ID_Equipe = (int)Record["ID_Equipe"];
                col.Nome = (string)Record["Nome"];
                col.Email = (string)Record["Email"];
                col.Funcao = (string)Record["ID_Funcao"];
                return col;
            }
        }
    
}