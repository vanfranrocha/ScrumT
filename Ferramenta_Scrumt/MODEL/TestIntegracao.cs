using System;

namespace Ferramenta_Scrumt.MODEL
{
    public class TestIntegracao
    {
        public TestIntegracao()
        {

        }
        public int ID { get; set; }
        public DateTime Data_Teste { get; set; }
        public string Versao { get; set; }
        public int ID_Backlog { get; set; }
        public string Historia { get; set; }
        public int ID_Membro { get; set; }
        public string Membro { get; set; }
        public string Rel_Log { get; set; }
        public string Erros { get; set; }
        public string Done { get; set; }
    }
}