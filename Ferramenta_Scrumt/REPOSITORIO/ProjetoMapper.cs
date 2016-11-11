using Ferramenta_Scrumt.MODEL;
using System;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class ProjetoMapper : SqlMapperBase<Projeto>
    {
        public override Projeto MapFromSource(DataRow Record)
        {
            Projeto proj = new Projeto();

            proj.ID = (int)Record["ID"];
            proj.Descricao = (string)Record["Descricao"];
            proj.Data_Inicio = (DateTime)Record["Data_Inicio"];
            proj.Data_Fim = (DateTime)Record["Data_Fim"];
            return proj;
        }
    }
    

}