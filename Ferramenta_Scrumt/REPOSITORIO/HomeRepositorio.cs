using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class HomeRepositorio : ISQLRepository<Home>
    {
        DBUtil DB = new DBUtil();

        public void ADD(Home Item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Home Item)
        {
            throw new NotImplementedException();
        }

        public Home FindByID(int ID, ISQLMapper<Home> mapper)
        {
            throw new NotImplementedException();
        }

        public List<Home> Listaqtprojetos(ISQLMapper<Home> mapper, string SQL)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<Home> Lista(ISQLMapper<Home> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string sql = "";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, sql).Tables[0]);
        }

        public void Update(Home Item)
        {
            throw new NotImplementedException();
        }
    }
}