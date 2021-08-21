using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImobiliariaContext;
using ImobiliariaEntities;

namespace ImobiliariaService.Donos
{
    public class Donos : IDonos
    {

        Imobiliaria db;

        public Donos(Imobiliaria db){
            this.db = db;

        }

        public IEnumerable<Dono> RetornaTodos()
        {
            return db.Donos.ToList();
        }

        public async Task<Dono> InsereDono(Dono dono)
        {
            if(dono != null){
                await db.Donos.AddAsync(dono);
                await db.SaveChangesAsync();
                return dono;
            }

            return null;
        }
        
        public async Task<Dono> AlteraDono(int id, Dono dono)
        {
            var donoAux = db.Donos.Find(id);
            if(donoAux != null){
                donoAux.id = dono.id;
                donoAux.nome = dono.nome;
                donoAux.idade = dono.idade;
                donoAux.imovel = dono.imovel;
                await db.SaveChangesAsync();
                return donoAux;

            }

            return null;
        }

        public bool DeletaDono(int id)
        {
            var donoAux = db.Donos.Find(id);
            if(donoAux != null){
                db.Donos.Remove(donoAux);
                db.SaveChanges();
                return true;

            }

            return false;
        }

    }
}