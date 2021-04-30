namespace ConcessionariaEntitiesLib
{
    public class Carro
    {
        public int CarroID{get; set;}
        public string Marca{get; set;}
        public string Modelo{get; set;}
        public int Ano{get; set;}

        //Foreign Key definition
        public int AgenciaID{get; set;}
        public Agencia Agencia{get; set;}
        
    }
}