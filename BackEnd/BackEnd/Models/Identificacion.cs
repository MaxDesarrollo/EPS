using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Identificacion
    {
        public string Numero { get; set; }
        public DateTime Fecha_Expedicion { get; set; }
        public DateTime Lugar_Expedicion { get; set; }
        public string Tipo { get; set; }
    }
}
