using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FendaBikiniApi.Models
{
    public class Personagens
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;}
        
        [BsonElement("nome")]
        public string nome { get; set;}

        [BsonElement("age")]
        public int age { get; set;}

        [BsonElement("profissao")]
        public string profissao { get; set; }

    }
}
