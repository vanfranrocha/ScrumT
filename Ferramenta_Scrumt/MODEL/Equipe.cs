using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ferramenta_Scrumt.MODEL
{
    public class Equipe
    {
        public Equipe()
        {

        }
        [Key]
        public int ID { get; set; }
        [Display (Name="Usuário")]
        public string Membro { get; set; }
        public int IDUser { get; set; }
        [Display(Name = "Projeto")]
        public int IDProjeto { get; set; }
    }
}