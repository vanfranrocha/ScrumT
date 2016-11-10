﻿using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class TesteUnidadeRepositorio : ISQLRepository<TesteUnidade>
    {
        DBUtil DB = new DBUtil();

        public TesteUnidade FindByID(int ID, ISQLMapper<TesteUnidade> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_TESTEUNIDADE_BYID", ID));
        }

        public List<TesteUnidade> Lista(ISQLMapper<TesteUnidade> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "SELECT* Teste_Unidade";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public void ADD(TesteUnidade Item)
        {
            SqlParameter ID = new SqlParameter("@ID_TestUnidade", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID_Backlog",Item.ID_Backlog),
                new SqlParameter("@ID_Membro",Item.ID_Membro),
                new SqlParameter("@Classe",Item.Classe),
                new SqlParameter("@Status",Item.Status),
                ID
            };

            DB.ExecSP("SP_TESTEUNIDADE_INCLUIR", Param);
        }

        public void Update(TesteUnidade Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
               new SqlParameter("@ID_Backlog",Item.ID_Backlog),
                new SqlParameter("@ID_Membro",Item.ID_Membro),
                new SqlParameter("@Classe",Item.Classe),
                new SqlParameter("@Status",Item.Status),
                new SqlParameter("@ID_TestUnidade",Item.ID)
            };

            DB.ExecSP("SP_TESTEUNIDADE_UPDATE", Param);
        }

        public void Delete(TesteUnidade Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_TESTEUNIDADE_DELETE", Param);

        }


    }
}