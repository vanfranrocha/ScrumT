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

            grf.jan = (int)Record["Janeiro"];
            grf.fev = (int)Record["Fevereiro"];
            grf.mar = (int)Record["Marco"];
            grf.abr = (int)Record["Abril"];
            grf.mai = (int)Record["Maio"];
            grf.jun = (int)Record["Junho"];
            grf.jul = (int)Record["Julho"];
            grf.ago = (int)Record["Agosto"];
            grf.set = (int)Record["Setembro"];
            grf.otb = (int)Record["Outubro"];
            grf.nov = (int)Record["Novembro"];
            grf.dez = (int)Record["Dezembro"];
            return grf;
        }
    }
}