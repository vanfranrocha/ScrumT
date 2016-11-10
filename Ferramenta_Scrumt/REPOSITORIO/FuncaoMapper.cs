using Ferramenta_Scrumt.MODEL;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class FuncaoMapper : SqlMapperBase<Funcao>
    {
        public override Funcao MapFromSource(DataRow Record)
        {
            Funcao fun = new Funcao();

            fun.ID_Funcao = (int)Record["ID_Funcao"];
            fun.Nome_Funcao = (string)Record["Nome_Funcao"];

            return fun;
        }
    }
}