using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class FuncaoRepositorio : ISQLRepository<Funcao>
    {
        DBUtil DB = new DBUtil();
        public void ADD(Funcao Item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Funcao Item)
        {
            throw new NotImplementedException();
        }

        public Funcao FindByID(int ID, ISQLMapper<Funcao> mapper)
        {
            throw new NotImplementedException();
        }

        public List<Funcao> Lista(ISQLMapper<Funcao> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "Select * from Funcao";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public void Update(Funcao Item)
        {
            throw new NotImplementedException();
        }

    }
}