using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImobiliariaContext;
using ImobiliariaEntities;

namespace ImobiliariaService.Imoveis
{
    public class Imoveis : IImoveis
    {

        Imobiliaria db;

        public Imoveis(Imobiliaria db){
            this.db = db;

        }

        public IEnumerable<Imovel> RetornaTodos()
        {
            return db.Imoveis.ToList();
        }

        public async Task<Imovel> InsereImovel(Imovel imovel)
        {
            if(imovel != null){
                await db.Imoveis.AddAsync(imovel);
                await db.SaveChangesAsync();
                return imovel;

            }

            return null;
        }

        public async Task<Imovel> AlteraImovel(int id, Imovel imovel)
        {
            var imovelAux = db.Imoveis.Find(id);
            if(imovelAux != null){
                imovelAux.id = imovel.id;
                imovelAux.idAgencia = imovel.idAgencia;
                imovelAux.idDono = imovel.idDono;
                imovelAux.endereco = imovel.endereco;
                imovelAux.preco = imovel.preco;
                await db.SaveChangesAsync();
                return imovelAux;

            }

            return null;
        }

        public bool DeletaImovel(int id)
        {
            var imovelAux = db.Imoveis.Find(id);
            if(imovelAux != null){
                db.Imoveis.Remove(imovelAux);
                db.SaveChanges();
                return true;

            }

            return false;
        }

    }
}