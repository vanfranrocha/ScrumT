using Ferramenta_Scrumt.MODEL;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class EquipeMapper : SqlMapperBase<Equipe>
    {
        public override Equipe MapFromSource(DataRow Record)
        {
            Equipe Eq = new Equipe();

            Eq.ID = (int)Record["ID_ProjUser"];
            Eq.Membro = (string)Record["Nome"];
            Eq.IDUser = (int)Record["ID_User"];
            Eq.IDProjeto = (int)Record["ID_Projeto"];
           
            return Eq;
        }
    }
}