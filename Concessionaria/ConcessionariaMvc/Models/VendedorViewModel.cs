using System.Collections.Generic;
using ConcessionariaEntitiesLib;

namespace ConcessionariaMvc.Models
{
    public class VendedorViewModel
    {
        public IEnumerable<Vendedor> Vendedores{get; set;}
    }
}