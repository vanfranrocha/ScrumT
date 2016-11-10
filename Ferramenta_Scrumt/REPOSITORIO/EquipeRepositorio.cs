using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class EquipeRepositorio : ISQLRepository<Equipe>
    {
        DBUtil DB = new DBUtil();
        public void ADD(Equipe Item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Equipe Item)
        {
            throw new NotImplementedException();
        }

        public Equipe FindByID(int ID, ISQLMapper<Equipe> mapper)
        {
            throw new NotImplementedException();
        }

        public List<Equipe> Lista(ISQLMapper<Equipe> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "select * from Equipe";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<Equipe> Lista(ISQLMapper<Equipe> mapper,int IDUser)
        {
            return Lista(new EquipeMapper()).Where(X => X.IDUser == IDUser).ToList();
        }

        public void Update(Equipe Item)
        {
            throw new NotImplementedException();
        }
    }
}