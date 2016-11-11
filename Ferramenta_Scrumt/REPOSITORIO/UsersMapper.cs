using Ferramenta_Scrumt.MODEL;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class UsersMapper : SqlMapperBase<Users>
        {
            public override Users MapFromSource(DataRow Record)
            {
                Users us = new Users();

                us.ID = (int)Record["ID_Equipe"];
                us.Nome = (string)Record["Nome"];
                us.Email = (string)Record["Email"];
                us.Funcao = (int)Record["ID_Funcao"];
                us.Nome_Funcao = (string)Record["Nome_Funcao"];
                us.Senha = (string)Record["Senha"];
                return us;
            }
        }
}