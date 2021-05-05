using System.Collections.Generic;
using ConcessionariaEntitiesLib;

namespace ConcessionariaMvc.Models
{
    public class GerenteViewModel
    {
        public IEnumerable<Gerente> Gerentes{get; set;}

        public Gerente Gerente{get; set;}
        
    }
}