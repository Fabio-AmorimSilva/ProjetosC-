namespace ConcessionariaEntitiesLib
{
    public class Gerente
    {
        public int GerenteID{get; set;}
        public string Nome{get; set;}
        public int Telefone{get; set;}

         //Foreign Key definition
        public int AgenciaID{get; set;}
        public Agencia Agencia{get; set;}
    
    }
}