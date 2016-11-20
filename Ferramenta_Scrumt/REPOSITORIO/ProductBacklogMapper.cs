using Ferramenta_Scrumt.MODEL;
using System;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class ProductBacklogMapper : SqlMapperBase<ProductBacklog>
    {
        public override ProductBacklog MapFromSource(DataRow Record)
        {
            ProductBacklog pback = new ProductBacklog();

            pback.ID = (int)Record["ID_PBacklog"];
            pback.Nome_Projeto = (string)Record["Descricao"];
            pback.Projeto = (int)Record["ID_Projeto"];
            pback.Historia = (string)Record["Historia"];
            pback.Aceito = (string)Record["Aceito"];
            pback.Importancia = (string)Record["Importancia"];
            return pback;
        }
    }
}