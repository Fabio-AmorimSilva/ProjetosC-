using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImobiliariaContext;
using ImobiliariaEntities;

namespace ImobiliariaService.Corretores
{
    public class Corretores : ICorretores
    {
        private Imobiliaria db;

        public Corretores(Imobiliaria db){
            this.db = db;

        }

        public IEnumerable<Corretor> RetornaTodos()
        {
            return db.Corretores.ToList();
        }

        public async Task<Corretor> InsereCorretor(Corretor corretor)
        {
            if(corretor != null){
                await db.Corretores.AddAsync(corretor);
                await db.SaveChangesAsync();
                return corretor;
            }

            return null;
            
        }

        public async Task<Corretor> AlteraCorretor(int id, Corretor corretor)
        {
            var corretorAux = db.Corretores.Find(id);
            if(corretorAux != null){
                corretorAux.id = corretor.id;
                corretorAux.idAgencia = corretor.idAgencia;
                corretorAux.nome = corretor.nome;
                corretorAux.idade = corretor.idade;
                corretorAux.vendas = corretor.vendas;
                await db.SaveChangesAsync();

            }

            return null;
        }

        public bool DeletaCorretor(int id)
        {
            var corretorAux = db.Corretores.Find(id);
            if(corretorAux != null){
                db.Corretores.Remove(corretorAux);
                db.SaveChanges();
                return true;

            }

            return false;

        }

       
    }
}