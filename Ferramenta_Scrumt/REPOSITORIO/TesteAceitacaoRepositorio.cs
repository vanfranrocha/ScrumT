using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class TesteAceitacaoRepositorio : ISQLRepository<TesteAceitacao>
    {
        DBUtil DB = new DBUtil();

        public void ADD(TesteAceitacao Item)
        {
            SqlParameter ID = new SqlParameter("@ID_TesteAceitacao", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID_Membro",Item.ID_Membro),
                new SqlParameter("@Data",Item.Data),
                new SqlParameter("@Stakeholders",Item.Stakeholders),
                new SqlParameter("@Massa",Item.Massa_Dados),
                new SqlParameter("@Relatorio",Item.Relatorio_F),
                ID
            };

            DB.ExecSP("SP_TESTEACEITACAO_INCLUIR", Param);
        }

        public void Delete(TesteAceitacao Item)
        {
            throw new NotImplementedException();
        }

        public TesteAceitacao FindByID(int ID, ISQLMapper<TesteAceitacao> mapper)
        {
            throw new NotImplementedException();
        }

        public List<TesteAceitacao> Lista(ISQLMapper<TesteAceitacao> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "SELECT [ID_TesteAceitacao],[Data_Teste],Users.[Nome],Teste_Aceitacao.ID_Membro, [Stakeholders],[Massa_Dados],[Relatorio_Final] FROM Teste_Aceitacao Inner Join Users on Teste_Aceitacao.ID_Membro = Users.ID_Equipe";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<TesteAceitacao> Listatest(ISQLMapper<TesteAceitacao> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "SELECT top 4 [ID_TesteAceitacao], [Data_Teste],Users.[Nome],Teste_Aceitacao.ID_Membro, [Stakeholders],[Massa_Dados],[Relatorio_Final] FROM Teste_Aceitacao Inner Join Users on Teste_Aceitacao.ID_Membro = Users.ID_Equipe";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public void Update(TesteAceitacao Item)
        {
            throw new NotImplementedException();
        }
    }
}