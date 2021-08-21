using System.Collections.Generic;
using System.Threading.Tasks;
using ImobiliariaEntities;

namespace ImobiliariaService.Imoveis
{
    public interface IImoveis
    {
         IEnumerable<Imovel> RetornaTodos();

         Task<Imovel> InsereImovel(Imovel imovel);

         Task<Imovel> AlteraImovel(int id, Imovel imovel);

         bool DeletaImovel(int id);

         
    }
}