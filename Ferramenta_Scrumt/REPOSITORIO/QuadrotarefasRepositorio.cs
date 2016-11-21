using System;
using System.Collections.Generic;
using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class QuadrotarefasRepositorio : ISQLRepository<Quadro_tarefas>
    {
        DBUtil DB = new DBUtil();

        public void ADD(Quadro_tarefas Item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Quadro_tarefas Item)
        {
            throw new NotImplementedException();
        }

        public Quadro_tarefas FindByID(int ID, ISQLMapper<Quadro_tarefas> mapper)
        {
            throw new NotImplementedException();
        }

        public List<Quadro_tarefas> Listaquadro(ISQLMapper<Quadro_tarefas> mapper, string SQL)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<Quadro_tarefas> Lista(ISQLMapper<Quadro_tarefas> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string sql = "";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, sql).Tables[0]);
        }
        public void Update(Quadro_tarefas Item)
        {
            throw new NotImplementedException();
        }
    }
}