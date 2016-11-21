using Ferramenta_Scrumt.MODEL;
using Ferramenta_Scrumt.REPOSITORIO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ferramenta_Scrumt.Controllers
{
    [Authorize]
    public class QuadrotarefasController : Controller
    {
        // GET: Quadrotarefas
        List<Quadro_tarefas> QtarefasList;
        QuadrotarefasRepositorio _QtarefasRep = new QuadrotarefasRepositorio();

        private void CarregaLista()
        {
            QtarefasList = _QtarefasRep.Listaquadro(new QuadrotarefasMapper(), "Select [Product_Backlog].[Historia],[Product_Release].[ID_PBacklog],[Situacao_Quadrotarefas] from Product_Release Inner Join Product_Backlog on Product_Release.ID_PBacklog = Product_Backlog.ID_PBacklog");
            Session["Lista"] = QtarefasList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(QtarefasList);
        }
    }
}