using System.Collections.Generic;
using ImobiliariaEntities;

namespace ImobiliariaMvc.Models
{
    public class ImovelViewModel
    {
        public IEnumerable<Imovel> Imoveis{get; set;}
        
    }
}