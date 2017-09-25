using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class GraficoRepositorio : ISQLRepository<Grafico>
    {
        DBUtil DB = new DBUtil();

        public void ADD(Grafico Item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Grafico Item)
        {
            throw new NotImplementedException();
        }

        public Grafico FindByID(int ID, ISQLMapper<Grafico> mapper)
        {
            throw new NotImplementedException();
        }

        public List<Grafico> Lista(ISQLMapper<Grafico> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
           { };
            string SQL = "select  [1] AS Janeiro, [2] AS Fevereiro,  [3] AS Marco,  [4] AS Abril,  [5] AS Maio,  [6] AS Junho,  [7] AS Julho,  [8] AS Agosto,  [9] AS Setembro,  [10] AS Outubro,  [11] AS Novembro,   [12] AS Dezembro from (SELECT MONTH(Estimativa_Inicio) AS month, [ID_ProductRelease] FROM Product_Release) AS t PIVOT (COUNT([ID_ProductRelease]) FOR month IN([1], [2], [3], [4], [5],[6],[7],[8],[9],[10],[11],[12]))p";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public void Update(Grafico Item)
        {
            throw new NotImplementedException();
        }
    }
}