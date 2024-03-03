using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts.Configuration
{
    public class RutaConfiguration : IEntityTypeConfiguration<Ruta>
    {
        public void Configure(EntityTypeBuilder<Ruta> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdRuta");

            builder.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsFixedLength();

            builder.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Ruta)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rutas_Usuarios");

            builder.HasOne(d => d.IdRecursoNavigation).WithMany(p => p.Ruta)
                .HasForeignKey(d => d.IdRecurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rutas_Recursos");
        }
    }
}
