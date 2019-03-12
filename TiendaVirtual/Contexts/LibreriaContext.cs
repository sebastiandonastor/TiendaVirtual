using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaVirtual.Entities;
using TiendaVirtual.EntitiesConfigurations;

namespace TiendaVirtual.Contexts
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
