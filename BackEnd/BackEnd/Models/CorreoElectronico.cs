using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class CorreoElectronico
    {
        [BsonElement("correo")]
        public string Correo { get; set; }
    }
}
