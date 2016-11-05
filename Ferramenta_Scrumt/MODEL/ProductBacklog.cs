using System;
using System.ComponentModel.DataAnnotations;

namespace Ferramenta_Scrumt.MODEL
{
    public class ProductBacklog
    {
        public int ID_PBacklog { get; set; }
        public int Projeto { get; set; }
        public string Historia { get; set; }
        [DataType(DataType.Date)]
        public DateTime Estimativa_Inicio { get; set; }
        public string Aceito { get; set; }
        public string Importancia { get; set; }

    }
}