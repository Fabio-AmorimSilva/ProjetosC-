using System.Collections.Generic;
using ImobiliariaEntities;

namespace ImobiliariaMvc.Models
{
    public class CorretorViewModel
    {
        
        public IEnumerable<Corretor> Corretores{get; set;}

        public Corretor Corretor{get; set;}

    }
}