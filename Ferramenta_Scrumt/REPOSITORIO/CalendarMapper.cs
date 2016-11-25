using Ferramenta_Scrumt.MODEL;
using System;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class CalendarMapper : SqlMapperBase<Calendar>
    {
        public override Calendar MapFromSource(DataRow Record)
        {
            Calendar cald = new Calendar();

            cald.title = (string)Record["Historia"];
            cald.start = Convert.ToString(Record["Estimativa_Inicio"]);
            return cald;
        }
    }
}