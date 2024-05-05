using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Contexts.Configuration
{
    internal class RecursoConfiguration : IEntityTypeConfiguration<Recurso>
    {
        public void Configure(EntityTypeBuilder<Recurso> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdRecurso");

            builder.HasIndex(e => e.IdCategoria, "IX_Recursos_IdCategoria");

            builder.HasIndex(e => e.IdProfesor, "IX_Recursos_IdProfesor");

            builder.Property(e => e.NombreRecurso).HasMaxLength(100);

            builder.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Recursos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recursos_Categoria");

            builder.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Recursos)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recursos_Usuarios");
        }
    }
}
