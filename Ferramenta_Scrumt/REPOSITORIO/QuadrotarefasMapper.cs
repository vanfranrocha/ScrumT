using Ferramenta_Scrumt.MODEL;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public class QuadrotarefasMapper : SqlMapperBase<Quadro_tarefas>
    {
        public override Quadro_tarefas MapFromSource(DataRow Record)
        {
            Quadro_tarefas qtarefas = new Quadro_tarefas();

            qtarefas.id_Pbacklog = (int)Record["ID_PBacklog"];
            qtarefas.Historia = (string)Record["Historia"];
            qtarefas.Projeto = (string)Record["Descricao"];
            qtarefas.Situacao = (string)Record["Situacao_Quadrotarefas"];
            qtarefas.Importancia = (string)Record["Importancia"];
            return qtarefas;
        }
    }
}