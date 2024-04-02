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
    public class CategoriumConfiguration : IEntityTypeConfiguration<Categorium>
    {
        public void Configure(EntityTypeBuilder<Categorium> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdCategoria");

            builder.Property(e => e.NombreCategoria)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombreCategoria");
        }
    }
}
