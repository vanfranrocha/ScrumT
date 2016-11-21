using Ferramenta_Scrumt.MODEL;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class HomeMapper : SqlMapperBase<Home>
    {
        public override Home MapFromSource(DataRow Record)
        {
            Home hom = new Home();

            hom.totalprojeto = (int)Record["totalprojeto"];
            hom.totalteste = (int)Record["totaltestes"];
            hom.totalhistorias = (int)Record["totalhistorias"];

            return hom;
        }
    }
}