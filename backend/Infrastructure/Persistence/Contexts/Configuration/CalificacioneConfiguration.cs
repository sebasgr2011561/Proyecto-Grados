﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts.Configuration
{
    public class CalificacioneConfiguration:IEntityTypeConfiguration<Calificacione>
    {
        public void Configure(EntityTypeBuilder<Calificacione> builder)
        {
            builder.HasKey(e => e.IdCalificacion);

            builder.HasOne(d => d.IdRecursoNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdRecurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calificaciones_Recursos");

            builder.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calificaciones_Usuarios");
        }
    }
}
