using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence.Contexts.Configuration
{
    internal class RecursoConfiguration : IEntityTypeConfiguration<Recurso>
    {
        public void Configure(EntityTypeBuilder<Recurso> builder)
        {
            builder.HasKey(e => e.IdRecurso);

            builder.Property(e => e.NombreRecurso).HasMaxLength(100);

            builder.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Recursos)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recursos_Usuarios");
        }
    }
}
