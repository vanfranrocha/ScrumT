using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class EquipeRepositorio : ISQLRepository<Equipe>
    {
        DBUtil DB = new DBUtil();

        public Equipe FindByID(int ID, ISQLMapper<Equipe> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_EQUIPE_BYID", ID));
        }

        public List<Equipe> Lista(ISQLMapper<Equipe> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "select * from Equipe";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public void ADD(Equipe Item)
        {
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Nome),
                new SqlParameter("@Email",Item.Email),
                new SqlParameter("@Funcao",Item.Funcao),
                ID
            };

            DB.ExecSP("SP_EQUIPE_INCLUIR", Param);
        }

        public void Update(Equipe Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Nome),
                new SqlParameter("@Email",Item.Email),
                new SqlParameter("@Funcao",Item.Funcao),
                new SqlParameter("@ID",Item.ID_Equipe)
            };

            DB.ExecSP("SP_EQUIPE_UPDATE", Param);
        }

        public void Delete(Equipe Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID_Equipe)
            };

            DB.ExecSP("SP_EQUIPE_DELETE", Param);

        }

       
    }
}