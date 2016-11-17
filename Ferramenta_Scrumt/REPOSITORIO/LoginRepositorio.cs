using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace APOIO_ITPAC.REPOSITORIO
{
    public class LoginRepositorio : ISQLRepository<Users>
    {
        DBUtil DB = new DBUtil();
        public void ADD(Users Item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Users Item)
        {
            throw new NotImplementedException();
        }

        public Users FindByID(int ID, ISQLMapper<Users> mapper)
        {
            throw new NotImplementedException();
        }

        public List<Users> Lista(ISQLMapper<Users> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "SELECT  [ID_Equipe],[Nome],Funcao.[Nome_Funcao],Users.[ID_Funcao],[Email],[Senha] FROM Users Inner Join Funcao on Users.ID_Funcao = Funcao.ID_Funcao";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }


        public Boolean Login(Users Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@user",Item.Email),
                new SqlParameter("@pass",Item.Senha),
            };


            string SQL = "SP_USERS_BYID";

            if (DB.Lista(Param, SQL).Tables[0].Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(Users Item)
        {
            throw new NotImplementedException();
        }
    }
}