using System;

namespace Ferramenta_Scrumt.MODEL
{
    public class Users
    {
        public Users()
        {

        }
        public int ID { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Nome_Funcao { get; set; }
        public int Funcao { get; set; }
        public String Senha { get; set; }
    }
}