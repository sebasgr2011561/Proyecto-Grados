using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Contexts.Configuration
{
    public class ModuloConfiguration : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdModulo");

            builder.Property(e => e.NombreModulo).HasMaxLength(100);
            builder.Property(e => e.Urlmodulo)
                .HasMaxLength(255)
                .HasColumnName("URLModulo");

            builder.HasOne(d => d.IdRecursoNavigation).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.IdRecurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modulos_Recursos");
        }
    }
}
