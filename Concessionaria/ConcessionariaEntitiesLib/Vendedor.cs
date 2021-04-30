namespace ConcessionariaEntitiesLib
{
    public class Vendedor
    {
        public int VendedorID{get; set;}
        public string Nome{get; set;}
        public int NumeroVendas{get; set;}


         //Foreign Key definition
        public int AgenciaID{get; set;}
        public Agencia Agencia{get; set;}
    }
}