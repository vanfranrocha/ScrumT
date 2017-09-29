using Ferramenta_Scrumt.MODEL;
using System;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class GraficoMapper : SqlMapperBase<Grafico>
    {
        public override Grafico MapFromSource(DataRow Record)
        {
            Grafico grf = new Grafico();

            grf.data = (int)Record["data"];
            grf.label = (string)Record["label"];
            return grf;
        }
    }
}