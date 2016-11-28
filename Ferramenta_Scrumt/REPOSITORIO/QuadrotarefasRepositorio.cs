using System;
using System.Collections.Generic;
using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System.Data.SqlClient;
using System.Linq;

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
        public List<Quadro_tarefas> Listaquadro(ISQLMapper<Quadro_tarefas> mapper, string SQL, List<Equipe> EquipeLista)
        {
            List<int> Projetos = new List<int>();
            foreach (Equipe E in EquipeLista)
                Projetos.Add(E.IDProjeto);

            return Lista(new QuadrotarefasMapper()).Where(X => Projetos.Contains(X.id_Projeto)).ToList();
        }
        public List<Quadro_tarefas> Lista(ISQLMapper<Quadro_tarefas> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string sql = "Select [Product_Backlog].[Historia],[Projeto].ID_Projeto,[Projeto].[Descricao],[Product_Release].[ID_PBacklog],[Situacao_Quadrotarefas], [Product_Backlog].[Importancia] from Product_Release Inner Join Product_Backlog on Product_Release.ID_PBacklog = Product_Backlog.ID_PBacklog Inner Join Projeto on Product_Backlog.ID_Projeto = Projeto.ID_Projeto group by Historia,Descricao,Projeto.ID_Projeto, Product_Backlog.ID_PBacklog, Product_Release.ID_PBacklog, Situacao_QuadroTarefas, Importancia";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, sql).Tables[0]);
        }
        public void Update(Quadro_tarefas Item)
        {
            throw new NotImplementedException();
        }
    }
}