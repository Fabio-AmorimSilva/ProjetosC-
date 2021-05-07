using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConcessionariaContextLib;
using ConcessionariaEntitiesLib;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ConcessionariaService.Carros
{
    public class Carros : ICarros
    {

        private Concessionaria db;

        public Carros(Concessionaria db){
            this.db = db;

        }

        public async Task<Carro> CriaAsync(Carro c)
        {
            if(c != null){
                await db.Carros.AddAsync(c);
                db.SaveChanges();
                return c;

            }else{
                return null;

            }
            
        }

        public Carro Retorna(int id)
        {
            Carro carroBusca = db.Carros.SingleOrDefault(carro => carro.CarroID == id);
            if(carroBusca != null){
                return carroBusca;

            }else{
                return null;

            }

        }

        public IEnumerable<Carro> RetornaTodos()
        {
            return db.Carros.ToList();
        }

        public Carro Atualiza(int id, Carro c)
        {
            
            Carro carroBusca = db.Carros.SingleOrDefault(carro => carro.CarroID == id);
            if(c != null && c.CarroID == id){
                carroBusca.Marca = c.Marca;
                carroBusca.Modelo = c.Modelo;
                carroBusca.Ano = c.Ano;
                return carroBusca;

            }else{
                return null;

            }
        }

        
        public bool Deleta(int id)
        {
            Carro carroBusca = db.Carros.Find(id);
            db.Carros.Remove(carroBusca);
            int affected = db.SaveChanges();
            if(affected == 1){
                return true;

            }else{
                return false;
                
            }
            
        }

       
    }
}