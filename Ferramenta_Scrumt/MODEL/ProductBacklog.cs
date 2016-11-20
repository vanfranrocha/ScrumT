using System;
using System.ComponentModel.DataAnnotations;

namespace Ferramenta_Scrumt.MODEL
{
    
    public class ProductBacklog
    {
        public ProductBacklog()
        {

        }
        public int ID { get; set; }
        public string Nome_Projeto { get; set; }
        public int Projeto { get; set; }
        public string Historia { get; set; }
        public string Aceito { get; set; }
        public string Importancia { get; set; }

    }
}