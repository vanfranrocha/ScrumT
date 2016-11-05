using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class FuncaoRepositorio : ISQLRepository<Funcao>
    {
        DBUtil DB = new DBUtil();

        public Funcao FindByID(int ID, ISQLMapper<Funcao> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_FUNCAO_BYID", ID));
        }

        public List<Funcao> Lista(ISQLMapper<Funcao> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "select * from Funcao";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public void ADD(Funcao Item)
        {
            SqlParameter ID = new SqlParameter("@ID_Projeto", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome_Funcao",Item.Nome_Funcao),
                ID
            };

            DB.ExecSP("SP_PROJETO_INCLUIR", Param);
        }

        public void Update(Funcao Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome_Funcao",Item.Nome_Funcao),
                new SqlParameter("@ID_Funcao",Item.ID_Funcao)
            };

            DB.ExecSP("SP_FUNCAO_UPDATE", Param);
        }

        public void Delete(Funcao Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID_Funcao",Item.ID_Funcao)
            };

            DB.ExecSP("SP_FUNCAO_DELETE", Param);

        }
    }
}