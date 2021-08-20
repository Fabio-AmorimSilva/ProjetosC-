using System.Collections.Generic;
using System.Threading.Tasks;
using ImobiliariaEntities;

namespace ImobiliariaService.Corretores
{
    public interface ICorretores
    {
         
         IEnumerable<Corretor> RetornaTodos();
         Task<Corretor> InsereCorretor(Corretor corretor);

         Task<Corretor> AlteraCorretor(int id, Corretor corretor);

         bool DeletaCorretor(int id);

         

    }
}