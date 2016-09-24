using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferramenta_Scrumt.MODEL
{
    public class Projeto
    {
        public int ID_Projeto { get; set; }
        public String Descricao { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Fim { get; set; }
    }
}