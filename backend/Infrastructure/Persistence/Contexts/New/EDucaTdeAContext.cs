using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts.New;

public partial class EDucaTdeAContext : DbContext
{
    public EDucaTdeAContext()
    {
    }

    public EDucaTdeAContext(DbContextOptions<EDucaTdeAContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignacion> Asignacions { get; set; }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Recurso> Recursos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ruta> Rutas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HAMILTONDEVTECH\\HAMILTONDEVTECH;Database=E-ducaTdeA;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignacion>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion);

            entity.ToTable("Asignacion");

            entity.HasIndex(e => e.IdEstudiante, "IX_Asignacion_IdEstudiante");

            entity.HasIndex(e => e.IdRecurso, "IX_Asignacion_IdRecurso");

            entity.Property(e => e.FechaAsignacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Usuarios");

            entity.HasOne(d => d.IdRecursoNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdRecurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Recursos");
        });

        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.IdRecurso);

            entity.HasIndex(e => e.IdRecurso1, "IX_Calificaciones_IdRecurso1");

            entity.HasIndex(e => e.IdUsuario, "IX_Calificaciones_IdUsuario");

            entity.HasOne(d => d.IdRecurso1Navigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdRecurso1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calificaciones_Recursos");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calificaciones_Usuarios");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PK__modulos__D9F153158349071D");

            entity.Property(e => e.NombreModulo).HasMaxLength(100);
            entity.Property(e => e.Urlmodulo)
                .HasMaxLength(255)
                .HasColumnName("URLModulo");

            entity.HasOne(d => d.IdRecursoNavigation).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.IdRecurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modulos_Recursos");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso);

            entity.HasIndex(e => e.IdRol, "IX_Permisos_IdRol");

            entity.Property(e => e.Permiso1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Permiso");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permisos_Roles");
        });

        modelBuilder.Entity<Recurso>(entity =>
        {
            entity.HasKey(e => e.IdRecurso);

            entity.HasIndex(e => e.IdCategoria, "IX_Recursos_IdCategoria");

            entity.HasIndex(e => e.IdProfesor, "IX_Recursos_IdProfesor");

            entity.Property(e => e.NombreRecurso).HasMaxLength(100);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Recursos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recursos_Categoria");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Recursos)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recursos_Usuarios");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.IdRuta);

            entity.HasIndex(e => e.IdEstudiante, "IX_Rutas_IdEstudiante");

            entity.HasIndex(e => e.IdRecurso, "IX_Rutas_IdRecurso");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Ruta)
                .HasForeignKey(d => d.IdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rutas_Usuarios");

            entity.HasOne(d => d.IdRecursoNavigation).WithMany(p => p.Ruta)
                .HasForeignKey(d => d.IdRecurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rutas_Recursos");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.HasIndex(e => e.IdRol, "IX_Usuarios_IdRol");

            entity.Property(e => e.Apellidos).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombres).HasMaxLength(50);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
