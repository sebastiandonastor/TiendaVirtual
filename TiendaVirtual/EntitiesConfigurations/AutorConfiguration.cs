using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaVirtual.Entities;

namespace TiendaVirtual.EntitiesConfigurations
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Libros)
                .WithOne(l => l.Autor)
                .HasForeignKey(l => l.IdAutor);
        }
        
    }
}
