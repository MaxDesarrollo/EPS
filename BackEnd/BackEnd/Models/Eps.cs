using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Eps
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("codigo")]
        public string Codigo { get; set; }

        [BsonElement("entidad")]
        public string Entidad { get; set; }

        [BsonElement("nit")]
        public string Nit { get; set; }

        [BsonElement("regimen_codigo")]
        public string Regimen_Codigo { get; set; }

        [BsonElement("regimen_descripcion")]
        public string Regimen_Descripcion { get; set; }
    }
}
