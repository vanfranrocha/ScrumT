using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferramenta_Scrumt.REPOSITORIO
{
    public interface ISQLRepository<T>
    {
        T FindByID(int ID, ISQLMapper<T> mapper);
        List<T> Lista(ISQLMapper<T> mapper);
        void ADD(T Item);
        void Update(T Item);
        void Delete(T Item);
    }
}
