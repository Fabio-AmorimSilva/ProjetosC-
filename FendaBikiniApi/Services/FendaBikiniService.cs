using FendaBikiniApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FendaBikiniApi.Services
{
    public class FendaBikiniService
    {
        private readonly IMongoCollection<Personagens> _personagens;

        public FendaBikiniService(IFendaBikiniDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _personagens = database.GetCollection<Personagens>(settings.FendaBikiniCollectionName);

        }

        public List<Personagens> Get() =>
            _personagens.Find(personagem => true).ToList();

        public Personagens Get(string id) =>
            _personagens.Find<Personagens>(persoangem => persoangem.Id == id).FirstOrDefault();

        public Personagens Create(Personagens personagem)
        {
            _personagens.InsertOne(personagem);
            return personagem;
        }

        public void Update(string id, Personagens personagemIn) =>
            _personagens.ReplaceOne(personagem => personagem.Id == id, personagemIn);

        public void Remove(Personagens personagemIn) =>
            _personagens.DeleteOne(personagem => personagem.Id == personagemIn.Id);

        public void Remove(string id) =>
            _personagens.DeleteOne(personagem => personagem.Id == id);
    }
}
