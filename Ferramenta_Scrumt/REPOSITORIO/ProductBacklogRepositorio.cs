using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class ProductBacklogRepositorio : ISQLRepository<ProductBacklog>
    {
        DBUtil DB = new DBUtil();

        public ProductBacklog FindByID(int ID, ISQLMapper<ProductBacklog> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_PBACKLOG_LIST_BYID", ID));
        }

        public List<ProductBacklog> Lista(ISQLMapper<ProductBacklog> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "SELECT [ID_PBacklog],[Historia],Projeto.[Descricao],Product_Backlog.[ID_Projeto],[Estimativa_Inicio],[Aceito],[Importancia] FROM Product_Backlog Inner Join Projeto on Product_Backlog.ID_Projeto = Projeto.ID_Projeto";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public void ADD(ProductBacklog Item)
        {
            SqlParameter ID = new SqlParameter("@ID_PBacklog", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@IDProjeto",Item.Projeto),
                new SqlParameter("@Historia",Item.Historia),
                new SqlParameter("@Estimativa",Item.Estimativa_Inicio),
                new SqlParameter("@Importancia",Item.Importancia),
                new SqlParameter("@Aceito",Item.Aceito),

                ID
            };

            DB.ExecSP("SP_PBACKLOG_INCLUIR", Param);
        }

        public void Update(ProductBacklog Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                 new SqlParameter("@ID_Projeto",Item.Projeto),
                new SqlParameter("@Historia",Item.Historia),
                new SqlParameter("@Estimativa",Item.Estimativa_Inicio),
                new SqlParameter("@Importancia",Item.Importancia),
                new SqlParameter("@Aceito",Item.Aceito),
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_PBACKLOG_UPDATE", Param);
        }

        public void Delete(ProductBacklog Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID_PBacklog",Item.ID)
            };

            DB.ExecSP("SP_PBACKLOG_DELETE", Param);

        }


    }
}