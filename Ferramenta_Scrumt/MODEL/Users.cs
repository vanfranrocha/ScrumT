using System;
using System.ComponentModel.DataAnnotations;

namespace Ferramenta_Scrumt.MODEL
{
    public class Users
    {
        public int ID_Equipe { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public int Funcao { get; set; }
        [Required]
        public String Senha { get; set; }
    }
}