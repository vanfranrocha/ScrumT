using System;
using System.ComponentModel.DataAnnotations;

namespace Ferramenta_Scrumt.MODEL
{
    public class Projeto
    {
        public Projeto()
        {

        }
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public DateTime Data_Inicio { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public DateTime Data_Fim { get; set; }
    }
}