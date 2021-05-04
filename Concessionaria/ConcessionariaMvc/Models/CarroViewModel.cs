using System.Collections.Generic;
using ConcessionariaEntitiesLib;

namespace ConcessionariaMvc.Models
{
    public class CarroViewModel
    {
        public IEnumerable<Carro> Carros{get; set;}

        public Carro Carro{get; set;}
    }
}