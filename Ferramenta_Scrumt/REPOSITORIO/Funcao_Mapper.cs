using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class FuncaoMapper : SqlMapperBase<Funcao>
    {
        public override Funcao MapFromSource(DataRow Record)
        {
            Funcao Fun = new Funcao();

            Fun.ID_Funcao = (int)Record["ID_Funcao"];
            Fun.Nome_Funcao = (string)Record["Nome_Funcao"];
            return Fun;
        }
    }
}