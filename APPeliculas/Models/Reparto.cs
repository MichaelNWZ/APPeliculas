using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPeliculas.Models
{
    public class Reparto
    {
        public int Id { get; set; }
        public int IdPelicula { get; set; }
        public int IdActor { get; set; }
    }
}
