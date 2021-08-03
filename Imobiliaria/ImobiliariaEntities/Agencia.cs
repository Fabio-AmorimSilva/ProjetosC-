using System;
using System.ComponentModel.DataAnnotations;

namespace ImobiliariaEntities
{
    public class Agencia
    {
        
        public int id{get; set;}

        public string nome;

        public string cidade;

        public int[] idCorretores;

        public int[] idImoveis;
        
    }
}