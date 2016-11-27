using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
            string SQL = "Select [ID_TesteIntegracao],[Data_Teste],[Versao_Testada],[Teste_Integracao].ID_PBacklog,Product_Backlog.Historia,Relatorio_Log,Erros, Teste_Integracao.Status, users.Nome  from Teste_Integracao Inner Join Product_Backlog on Teste_Integracao.ID_PBacklog = Product_Backlog.ID_PBacklog Inner Join Users on Teste_Integracao.ID_Membro = Users.ID_Equipe ";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<TesteUnidade> Listatest(ISQLMapper<TesteUnidade> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "Select top 4 Product_Backlog.Historia, Teste_Unidade.Status,Users.[Nome], Teste_Unidade.ID_Backlog, Teste_Unidade.ID_Membro, Teste_Unidade.ID_TestUnidade, Teste_Unidade.Classe from Teste_Unidade Inner Join Product_Backlog on Teste_Unidade.ID_Backlog = Product_Backlog.ID_PBacklog Inner Join Users on Teste_Unidade.ID_Membro = Users.ID_Equipe";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public void Update(TestIntegracao Item)
        {
            throw new NotImplementedException();
        }
    }
}