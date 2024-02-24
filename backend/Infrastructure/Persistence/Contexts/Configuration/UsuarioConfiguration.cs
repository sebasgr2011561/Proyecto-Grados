﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Contexts.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdUsuario");

            builder.Property(e => e.Apellidos).HasMaxLength(150);
            builder.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Nombres).HasMaxLength(50);

            builder.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        }
    }
}
