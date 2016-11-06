using System;
using System.Data;
using Ferramenta_Scrumt.MODEL;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class LoginMapper : SqlMapperBase<Users>
    {
        public override Users MapFromSource(DataRow Record)
        {
            Users Eq = new Users();

            Eq.ID_Equipe = (int)Record["ID_Equipe"];
            Eq.Nome = (string)Record["Nome"];
            Eq.Email = (string)Record["Email"];
            Eq.Senha = (string)Record["Senha"];
            return Eq;
        }
    }
}