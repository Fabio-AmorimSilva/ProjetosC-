using System.Collections.Generic;
using ConcessionariaEntitiesLib;

namespace ConcessionariaMvc.Models
{
    public class AgenciaViewModel
    {
        public IEnumerable<Agencia> Agencias{get; set;}

        public Agencia Agencia{get; set;}
        
    }
}