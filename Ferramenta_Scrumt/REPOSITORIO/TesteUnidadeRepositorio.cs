using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class TesteUnidadeRepositorio : ISQLRepository<TesteUnidade>
    {
        DBUtil DB = new DBUtil();

        public TesteUnidade FindByID(int ID, ISQLMapper<TesteUnidade> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_TESTEUNIDADE_BYID", ID));
        }

        public List<TesteUnidade> Lista(ISQLMapper<TesteUnidade> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "SELECT [ID_TestUnidade],Teste_Unidade.[ID_Backlog],Product_Backlog.[Historia],Users.[Nome],Teste_Unidade.ID_Membro, [Classe],[Status] FROM Teste_Unidade Inner Join Product_Backlog on Teste_Unidade.ID_Backlog = Product_Backlog.ID_PBacklog Inner Join Users on Teste_Unidade.ID_Membro = Users.ID_Equipe";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<TesteUnidade> Listatest(ISQLMapper<TesteUnidade> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "Select top 4 Product_Backlog.Historia, Teste_Unidade.Status,Users.[Nome], Teste_Unidade.ID_Backlog, Teste_Unidade.ID_Membro, Teste_Unidade.ID_TestUnidade, Teste_Unidade.Classe from Teste_Unidade Inner Join Product_Backlog on Teste_Unidade.ID_Backlog = Product_Backlog.ID_PBacklog Inner Join Users on Teste_Unidade.ID_Membro = Users.ID_Equipe";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public void ADD(TesteUnidade Item)
        {
            SqlParameter ID = new SqlParameter("@ID_TestUnidade", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID_Backlog",Item.ID_Backlog),
                new SqlParameter("@ID_Membro",Item.ID_Membro),
                new SqlParameter("@Classe",Item.Classe),
                new SqlParameter("@Status",Item.Status),
                ID
            };

            DB.ExecSP("SP_TESTEUNIDADE_INCLUIR", Param);
        }

        public void Update(TesteUnidade Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID_Backlog",Item.ID_Backlog),
                new SqlParameter("@ID_Membro",Item.ID_Membro),
                new SqlParameter("@Classe",Item.Classe),
                new SqlParameter("@Status",Item.Status),
                
            };

            DB.ExecSP("SP_TESTEUNIDADE_UPDATE", Param);
        }

        public void Delete(TesteUnidade Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_TESTEUNIDADE_DELETE", Param);

        }


    }
}