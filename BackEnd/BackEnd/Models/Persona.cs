using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Persona
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("schema_version")]
        public string Schema_version { get; set; }

        [BsonElement("document_version")]
        public string Document_version { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonElement("fecha_creacion")]
        public DateTime Fecha_Creacion { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonElement("fecha_ultima_modificacion")]
        public DateTime Fecha_Ultima_Modificacion { get; set; }

        [BsonElement("codigo_interno")]
        public string Codigo_Interno { get; set; }

        [BsonElement("Primer_Nombre")]
        public string Primer_Nombre { get; set; }
        [BsonElement("Segundo_Nombre")]
        public string Segundo_Nombre { get; set; }
        [BsonElement("Primer_Apellido")]
        public string Primer_Apellido { get; set; }
        [BsonElement("Segundo_Apellido")]
        public string Segundo_Apellido { get; set; }

        [BsonElement("identificacion")]
        public Identificacion Identificacion { get; set; }

        [BsonElement("estado_civil")]
        public string Estado_Civil { get; set; }

        [BsonElement("sexo")]
        public string Sexo { get; set; }

        [BsonElement("correo_electronico")]
        public List<CorreoElectronico> Correos { get; set; }

        [BsonElement("fecha_nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }

        [BsonElement("core_eps")]
        public Eps Core_Eps { get; set; }

        
    }
}
