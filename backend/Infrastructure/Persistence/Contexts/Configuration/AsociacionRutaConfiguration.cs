using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Contexts.Configuration
{
	public class AsociacionRutaConfiguration : IEntityTypeConfiguration<AsociacionRuta>
    {
        public void Configure(EntityTypeBuilder<AsociacionRuta> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdAsociacionRuta");

            builder.ToTable("AsociacionRuta");

            builder.HasOne(d => d.IdRutaNavigation).WithMany(p => p.AsociacionRutas)
                .HasForeignKey(d => d.IdRuta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AsociacionRuta_Rutas");

            builder.HasOne(d => d.IdRecursoNavigation).WithMany(p => p.AsociacionRutas)
                .HasForeignKey(d => d.IdRecurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Recursos");
        }
    }
}

