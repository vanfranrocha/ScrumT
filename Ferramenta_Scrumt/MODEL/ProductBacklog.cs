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
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Projeto { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Historia { get; set; }
        [DataType(DataType.Date)]
        public DateTime Estimativa_Inicio { get; set; }
        public string Aceito { get; set; }
        public string Importancia { get; set; }

    }
}