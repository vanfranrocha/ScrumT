using System;

namespace Ferramenta_Scrumt.MODEL
{
    public class TesteUnidade
    {
        public int ID_TestUnidade { get; set; }
        public int ID_Membro { get; set; }
        public int ID_Backlog { get; set; }
        public String Classe { get; set; }
        public String Status { get; set; }
    }
}