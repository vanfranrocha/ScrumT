using System.Collections.Generic;
using System.Data;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public interface ISQLMapper<T>
    {
        T MapFromSource(DataRow Record);
        List<T> MapAllFromSource(DataTable Tabela);
    }
}
