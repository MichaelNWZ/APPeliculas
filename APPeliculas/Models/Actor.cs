using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPeliculas.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_de_Naciemiento { get; set; }
    }
}
