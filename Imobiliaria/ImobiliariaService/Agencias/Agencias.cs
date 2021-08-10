using System.Collections.Generic;
using System.Linq;
using ImobiliariaContext;
using ImobiliariaEntities;

namespace ImobiliariaService.Agencias
{
    public class Agencias : IAgencias
    {

        private Imobiliaria db;

        public Agencias(Imobiliaria db){
            this.db = db;

        }

        public IEnumerable<Agencia> RetornaTodas()
        {
            return db.Agencias.ToList();
        }

        public Agencia InsereAgencia(Agencia agencia)
        {
            var agenciaAux = db.Agencias.Find(agencia.id);
            if(agenciaAux == null){
                db.Agencias.Add(agencia);
                db.SaveChanges();
                return agencia;

            }

            return null;

        }

        public Agencia AlteraAgencia(int id, Agencia agencia)
        {
            var agenciaAux = db.Agencias.Find(id);
            if(agenciaAux != null){
                agenciaAux.nome = agencia.nome;
                agenciaAux.cidade = agencia.cidade;
                agenciaAux.idCorretores = agencia.idCorretores;
                agenciaAux.idImoveis = agencia.idImoveis;
                return agenciaAux;

            }

            return null;

        }

        public bool DeletaAgencia(int id)
        {
            var agenciaAux = db.Agencias.Find(id);
            if(agenciaAux != null){
                db.Agencias.Remove(agenciaAux);
                return true;

            }

            return false;
            
        }

      
    }
}