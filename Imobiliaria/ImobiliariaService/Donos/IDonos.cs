using System.Collections.Generic;
using System.Threading.Tasks;
using ImobiliariaEntities;

namespace ImobiliariaService.Donos
{
    public interface IDonos
    {
         IEnumerable<Dono> RetornaTodos();

         Task<Dono> InsereDono(Dono dono);

         Task<Dono> AlteraDono(int id, Dono dono);

         bool DeletaDono(int id);

         
    }
}