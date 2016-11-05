using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class UsersRepositorio : ISQLRepository<Users>
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
            string SQL = "SELECT * FROM Users";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public void ADD(Users Item)
        {
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Nome),
                new SqlParameter("@Email",Item.Email),
                new SqlParameter("@ID_Funcao",Item.Funcao),
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
                new SqlParameter("@ID",Item.ID_Equipe)
            };

            DB.ExecSP("SP_USERS_UPDATE", Param);
        }

        public void Delete(Users Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID_Equipe)
            };

            DB.ExecSP("SP_USERS_DELETE", Param);

        }

       
    }
}