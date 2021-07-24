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
        public ObjectId Id { get; set; }
        public string Codigo { get; set; }
        public string Entidad { get; set; }
        public string Nit { get; set; }
        public string Regimen_Codigo { get; set; }
        public string Regimen_Descripcion { get; set; }
    }
}
