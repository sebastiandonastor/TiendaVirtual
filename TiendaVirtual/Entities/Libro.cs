using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaVirtual.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public String Titulo { get; set; }

        public int IdAutor { get; set; }
        public Autor Autor { get; set; }
    }
}
