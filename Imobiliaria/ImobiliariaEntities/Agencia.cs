using System;
using System.ComponentModel.DataAnnotations;

namespace ImobiliariaEntities
{
    public class Agencia
    {
        
        public int id{get; set;}

        public string nome{get; set;}

        public string cidade{get; set;}

        public int idCorretores{get; set;}

        public int idImoveis{get; set;}
        
    }
}