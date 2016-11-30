using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferramenta_Scrumt.MODEL
{
    public class TesteAceitacao
    {
        public TesteAceitacao()
        {

        }
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public int ID_Membro { get; set; }
        public string Membro { get; set; }
        public string Stakeholders { get; set; }
        public string Massa_Dados { get; set; }
        public string Relatorio_F { get; set; }
    }
}