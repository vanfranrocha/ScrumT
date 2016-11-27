using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class TesteIntegracaoRepositorio : ISQLRepository<TestIntegracao>
    {
        DBUtil DB = new DBUtil();

        public void ADD(TestIntegracao Item)
        {
            throw new NotImplementedException();
        }

        public void Delete(TestIntegracao Item)
        {
            throw new NotImplementedException();
        }

        public TestIntegracao FindByID(int ID, ISQLMapper<TestIntegracao> mapper)
        {
            throw new NotImplementedException();
        }

        public List<TestIntegracao> Lista(ISQLMapper<TestIntegracao> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "Select [ID_TesteIntegracao],[Data_Teste],[Versao_Testada],[Teste_Integracao].ID_PBacklog,Product_Backlog.Historia,Relatorio_Log,Erros, Teste_Integracao.Status, ID_Membro,users.Nome  from Teste_Integracao Inner Join Product_Backlog on Teste_Integracao.ID_PBacklog = Product_Backlog.ID_PBacklog Inner Join Users on Teste_Integracao.ID_Membro = Users.ID_Equipe ";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<TestIntegracao> Listatest(ISQLMapper<TestIntegracao> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "Select top 4 Product_Backlog.Historia, Teste_Integracao.Status,Users.[Nome],Teste_Integracao.Versao_Testada,Teste_Integracao.Relatorio_Log,Teste_Integracao.Erros, Teste_Integracao.ID_PBacklog, Teste_Integracao.ID_Membro, Teste_Integracao.ID_TesteIntegracao, Teste_Integracao.Data_Teste from Teste_Integracao Inner Join Product_Backlog on Teste_Integracao.ID_PBacklog = Product_Backlog.ID_PBacklog Inner Join Users on Teste_Integracao.ID_Membro = Users.ID_Equipe";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public void Update(TestIntegracao Item)
        {
            throw new NotImplementedException();
        }
    }
}