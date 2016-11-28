using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class ReleaseBacklogRepositorio : ISQLRepository<ReleaseBacklog>
    {
        DBUtil DB = new DBUtil();

        public ReleaseBacklog FindByID(int ID, ISQLMapper<ReleaseBacklog> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_RBACKLOG_BYID", ID));
        }

        public List<ReleaseBacklog> Lista(ISQLMapper<ReleaseBacklog> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "Select [ID_ProductRelease],[Product_Backlog].[ID_PBacklog], [Product_Backlog].Historia,[Users].[Nome],[ID_Membro],[Estimativa_Inicio],[Estimativa_Fim],[Situacao_QuadroTarefas] from Product_Release Inner Join Users on Product_Release.ID_Membro = Users.ID_Equipe Inner Join Product_Backlog on Product_Release.ID_PBacklog = Product_Backlog.ID_PBacklog";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public void ADD(ReleaseBacklog Item)
        {
            SqlParameter ID = new SqlParameter("@ID_RBacklog", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@IDMembro",Item.ID_Membro),
                new SqlParameter("@IDPbacklog",Item.ID_Pbacklog),
                new SqlParameter("@Situacao",Item.Situacao_Quadro),
                new SqlParameter("@Estimativai",Item.Estimativa_inicio),
                new SqlParameter("@Estimativaf",Item.Estimativa_fim),
                ID
            };

            DB.ExecSP("SP_RBACKLOG_INCLUIR", Param);
        }

        public void Update(ReleaseBacklog Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID_Membro",Item.ID_Membro),
                new SqlParameter("@ID_PBacklog",Item.ID_Pbacklog),
                new SqlParameter("@Situacao",Item.Situacao_Quadro),
                new SqlParameter("@Estimativai",Item.Estimativa_inicio),
                new SqlParameter("@Estimativaf",Item.Estimativa_fim),
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_RBACKLOG_UPDATE", Param);
        }

        public void Delete(ReleaseBacklog Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_RBACKLOG_DELETE", Param);

        }


    }
}