using Ferramenta_Scrumt.MODEL;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class ReleaseBacklogMapper : SqlMapperBase<ReleaseBacklog>
    {
        public override ReleaseBacklog MapFromSource(DataRow Record)
        {
            ReleaseBacklog relback = new ReleaseBacklog();

            relback.ID = (int)Record["ID_Projeto"];
            relback.ID_Membro = (int)Record["ID_Membro"];
            relback.ID_Pbacklog = (int)Record["ID_PBacklog"];
            relback.Nome_Membro = (string)Record["Nome"];
            relback.Situacao_Quadro = (string)Record["Situacao_QuadroTarefas"];
            relback.Historia = (string)Record["Historia"];
            return relback;
        }
    }
}