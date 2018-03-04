using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class RegistrationRepositorio : ISQLRepository<Users>
    {
        DBUtil DB = new DBUtil();

        public Users FindByID(int ID, ISQLMapper<Users> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_USERS_BYID", ID));
        }

        public List<Users> Lista(ISQLMapper<Users> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "select * from Users";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<Users> Lista2(ISQLMapper<Users> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "SELECT  [ID_Equipe],[Nome],Funcao.[Nome_Funcao],Users.[ID_Funcao],[Email],[Senha] FROM Users Inner Join Funcao on Users.ID_Funcao = Funcao.ID_Funcao";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }


        public Boolean Registro(Users Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@user",Item.Email)
            };


            string SQL = "SP_REGISTRO_BYID";

            if (DB.Lista(Param, SQL).Tables[0].Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ADD(Users Item)
        {
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Nome),
                new SqlParameter("@Email",Item.Email),
                new SqlParameter("@Senha",Item.Senha),
                ID
            };

            DB.ExecSP("SP_USERS_INCLUIR", Param);
        }

        public void Update(Users Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Nome),
                new SqlParameter("@Email",Item.Email),
                new SqlParameter("@ID_Funcao",Item.Funcao),
                new SqlParameter("@ID_Equipe",Item.ID)
            };

            DB.ExecSP("SP_USERS_UPDATE", Param);
        }

        public void Delete(Users Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_USERS_DELETE", Param);

        }


    }
}