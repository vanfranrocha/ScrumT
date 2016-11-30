using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class TesteSistemaRepositorio : ISQLRepository<TesteSistema>
    {
        DBUtil DB = new DBUtil();

        public void ADD(TesteSistema Item)
        {
            SqlParameter ID = new SqlParameter("@ID_TesteSistema", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Falhas",Item.Falhas),
                new SqlParameter("@Relatorio",Item.Relatorio),
                new SqlParameter("@Versao",Item.Versao),
                new SqlParameter("@Massa",Item.Massa_Dados),
                new SqlParameter("@ID_Membro",Item.ID_Membro),
                new SqlParameter("@Data",Item.Data_Teste),
                new SqlParameter("@Status",Item.Status),
                ID
            };

            DB.ExecSP("SP_TESTESISTEMA_INCLUIR", Param);
        }

        public void Delete(TesteSistema Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID_TesteSistema",Item.ID)
            };

            DB.ExecSP("SP_TESTESISTEMA_DELETE", Param);
        }

        public TesteSistema FindByID(int ID, ISQLMapper<TesteSistema> mapper)
        {
            throw new NotImplementedException();
        }

        public List<TesteSistema> Lista(ISQLMapper<TesteSistema> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "Select [ID_TesteSistema],[Data_Teste],[Versao_Testada], Users.Nome,[ID_Membro], [Relatorio_Log], [Massa_Dados], [Falhas_Encontradas], [Status] from Teste_Sistema Inner Join Users on Teste_Sistema.ID_Membro = Users.ID_Equipe";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<TesteSistema> Listatest(ISQLMapper<TesteSistema> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "Select top 4 [ID_TesteSistema],[Data_Teste],[Versao_Testada], Users.Nome,[ID_Membro], [Relatorio_Log], [Massa_Dados], [Falhas_Encontradas], [Status] from Teste_Sistema Inner Join Users on Teste_Sistema.ID_Membro = Users.ID_Equipe";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public void Update(TesteSistema Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
               new SqlParameter("@Falhas",Item.Falhas),
                new SqlParameter("@Relatorio",Item.Relatorio),
                new SqlParameter("@Versao",Item.Versao),
                new SqlParameter("@ID_Membro",Item.ID_Membro),
                new SqlParameter("@Data_Teste",Item.Data_Teste),
                new SqlParameter("@Status",Item.Status),

            };

            DB.ExecSP("SP_TESTESISTEMA_UPDATE", Param);
        }
    }
}