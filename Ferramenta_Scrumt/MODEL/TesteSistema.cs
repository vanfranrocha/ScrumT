using System;

namespace Ferramenta_Scrumt.MODEL
{
    public class TesteSistema
    {
        public TesteSistema()
        {

        }
        public int ID { get; set; }
        public DateTime Data_Teste { get; set; }
        public string Versao { get; set; }
        public string Membro { get; set; }
        public int ID_Membro { get; set; }
        public string Relatorio { get; set; }
        public string Massa_Dados { get; set; }
        public string Falhas { get; set; }
        public string Status { get; set; }
    }
}