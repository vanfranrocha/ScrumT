using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class CalendarRepositorio : ISQLRepository<Calendar>
    {
        DBUtil DB = new DBUtil();

        public void ADD(Calendar Item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Calendar Item)
        {
            throw new NotImplementedException();
        }

        public Calendar FindByID(int ID, ISQLMapper<Calendar> mapper)
        {
            throw new NotImplementedException();
        }

        public List<Calendar> Lista(ISQLMapper<Calendar> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
           { };
            string SQL = "Select Historia, Left(Estimativa_Inicio,10) As Estimativa_Inicio, Left(Estimativa_Fim,10) As Estimativa_Fim from Product_Release Inner Join Product_Backlog on Product_Backlog.ID_PBacklog = Product_Release.ID_PBacklog";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<Calendar> Lista2(ISQLMapper<Calendar> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
           { };
            string SQL = "Select Count(Estimativa_Inicio) As Historia from Product_Release Inner Join Product_Backlog on Product_Backlog.ID_PBacklog = Product_Release.ID_PBacklog where MONTH(Estimativa_Inicio) = Month(GETDATE())";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public void Update(Calendar Item)
        {
            throw new NotImplementedException();
        }
    }
}