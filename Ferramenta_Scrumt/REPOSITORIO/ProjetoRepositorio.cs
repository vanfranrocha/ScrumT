using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class ProjetoRepositorio : ISQLRepository<Projeto>
    {
        DBUtil DB = new DBUtil();

        public Projeto FindByID(int ID, ISQLMapper<Projeto> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_PROJETO_BYID", ID));
        }

        public List<Projeto> Lista(ISQLMapper<Projeto> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "select * from Projeto";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public void ADD(Projeto Item)
        {
            SqlParameter ID = new SqlParameter("@ID_Projeto", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Descricao),
                new SqlParameter("@Email",Item.Data_Inicio),
                new SqlParameter("@Funcao",Item.Data_Fim),
                ID
            };

            DB.ExecSP("SP_PROJETO_INCLUIR", Param);
        }

        public void Update(Projeto Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Descricao),
                new SqlParameter("@Email",Item.Data_Inicio),
                new SqlParameter("@Funcao",Item.Data_Fim),
                new SqlParameter("@ID",Item.ID_Projeto)
            };

            DB.ExecSP("SP_PROJETO_UPDATE", Param);
        }

        public void Delete(Projeto Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID_Projeto)
            };

            DB.ExecSP("SP_PROJETO_DELETE", Param);

        }


    }
}