using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Identificacion
    {
        [BsonElement("numero")]
        public string Numero { get; set; }

        [BsonElement("fecha_expedicion")]
        public DateTime Fecha_Expedicion { get; set; }


        [BsonElement("lugar_expedicion")]
        public DateTime Lugar_Expedicion { get; set; }


        [BsonElement("tipo")]
        public string Tipo { get; set; }
    }
}
