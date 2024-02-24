using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Contexts.Configuration
{
    internal class PermisoConfiguration : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.HasKey(e => e.IdPermiso);

            builder.Property(e => e.Permiso1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Permiso");

            builder.HasOne(d => d.IdRolNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permisos_Roles");
        }
    }
}
