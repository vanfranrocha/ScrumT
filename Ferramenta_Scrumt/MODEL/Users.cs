using System;
using System.ComponentModel.DataAnnotations;

namespace Ferramenta_Scrumt.MODEL
{
    public class Users
    {
        public Users()
        {

        }
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public String Email { get; set; }
        public String Nome_Funcao { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Funcao { get; set; }
        public String Senha { get; set; }
    }
}