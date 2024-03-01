using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Contexts.Configuration
{
    public class AsignacionConfiguration : IEntityTypeConfiguration<Asignacion>
    {
        public void Configure(EntityTypeBuilder<Asignacion> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdAsignacion");

            builder.ToTable("Asignacion");

            builder.Property(e => e.FechaAsignacion).HasColumnType("datetime");

            builder.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Usuarios");

            builder.HasOne(d => d.IdRecursoNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdRecurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Recursos");
        }
    }
}
