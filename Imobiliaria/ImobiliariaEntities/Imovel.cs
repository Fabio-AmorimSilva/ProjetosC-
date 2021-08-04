using System;

namespace ImobiliariaEntities
{
    public class Imovel
    {
        
        public int id{get; set;}

        public int idDono{get; set;}

        public int idAgencia{get; set;}

        public string endereco{get; set;}

        public double preco{get; set;}
    }
}