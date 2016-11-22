using System;
using System.ComponentModel.DataAnnotations;

namespace Ferramenta_Scrumt.MODEL
{
    public class ReleaseBacklog
    {
        public ReleaseBacklog()
        {

        }
        public int ID { get; set; }
        public string Historia { get; set; }
        public int ID_Pbacklog { get; set; }
        public string Nome_Membro { get; set; }
        public int ID_Membro { get; set; }
        public string Estimativa_inicio { get; set; }
        public string Situacao_Quadro { get; set; }

    }
}