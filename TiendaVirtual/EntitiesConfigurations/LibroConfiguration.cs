using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaVirtual.Entities;

namespace TiendaVirtual.EntitiesConfigurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libros");
            builder.HasKey(l => l.Id);
        }
    }
}
