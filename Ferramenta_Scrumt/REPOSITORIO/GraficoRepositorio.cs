using Ferramenta_Scrumt.INFRA;
using Ferramenta_Scrumt.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            string SQL = "Select Count(Teste_Aceitacao.ID_TesteAceitacao) As data, 'Teste de Aceitação' As label from Teste_Aceitacao Union  All Select Count(Teste_Integracao.ID_TesteIntegracao) As data, 'Teste de Integração' As label from Teste_Integracao Union All Select Count(Teste_Unidade.ID_TestUnidade) As data, 'Teste de Unidade' As label from Teste_Unidade Union All  Select Count(Teste_Sistema.ID_TesteSistema) As data, 'Teste de Sistema' As label from Teste_Sistema";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public List<Grafico> Lista2(ISQLMapper<Grafico> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
           { };
            string SQL = "Select Count(Teste_Aceitacao.ID_TesteAceitacao) As value, '#2a323f' As color from Teste_Aceitacao Union  All Select Count(Teste_Integracao.ID_TesteIntegracao) As Value, '#5f728f' As color from Teste_Integracao Union All Select Count(Teste_Unidade.ID_TestUnidade) As value,'#222' As color from Teste_Unidade Union All  Select Count(Teste_Sistema.ID_TesteSistema) As value, '#6dc5a3' As color from Teste_Sistema";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }
        public void Update(Grafico Item)
        {
            throw new NotImplementedException();
        }
    }
}