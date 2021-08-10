using System.Collections.Generic;
using ImobiliariaEntities;

namespace ImobiliariaService.Agencias
{
    public interface IAgencias
    {
         IEnumerable<Agencia> RetornaTodas();
         Agencia InsereAgencia(Agencia agencia);

         Agencia AlteraAgencia(int id, Agencia agencia);
         bool DeletaAgencia(int id);
         
    }
}