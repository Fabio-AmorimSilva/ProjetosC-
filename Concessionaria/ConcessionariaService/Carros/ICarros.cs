using System.Collections.Generic;
using System.Threading.Tasks;
using ConcessionariaEntitiesLib;

namespace ConcessionariaService.Carros
{
    public interface ICarros
    {
         Task<Carro> CriaAsync(Carro c);
         IEnumerable<Carro> RetornaTodos();
         Carro Retorna(int id);
         Carro Atualiza(int id, Carro c);
         bool Deleta(int id);
         
    }
}