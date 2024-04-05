using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCategoria = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    Permiso = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.IdPermiso);
                    table.ForeignKey(
                        name: "FK_Permisos_Roles",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Recursos",
                columns: table => new
                {
                    IdRecurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfesor = table.Column<int>(type: "int", nullable: false),
                    NombreRecurso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenPortada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recursos", x => x.IdRecurso);
                    table.ForeignKey(
                        name: "FK_Recursos_Categoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria");
                    table.ForeignKey(
                        name: "FK_Recursos_Usuarios",
                        column: x => x.IdProfesor,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Asignacion",
                columns: table => new
                {
                    IdAsignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    IdRecurso = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignacion", x => x.IdAsignacion);
                    table.ForeignKey(
                        name: "FK_Asignacion_Recursos",
                        column: x => x.IdRecurso,
                        principalTable: "Recursos",
                        principalColumn: "IdRecurso");
                    table.ForeignKey(
                        name: "FK_Asignacion_Usuarios",
                        column: x => x.IdEstudiante,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    IdRecurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdRecurso1 = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.IdRecurso);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Recursos",
                        column: x => x.IdRecurso1,
                        principalTable: "Recursos",
                        principalColumn: "IdRecurso");
                    table.ForeignKey(
                        name: "FK_Calificaciones_Usuarios",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    IdRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    IdRecurso = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.IdRuta);
                    table.ForeignKey(
                        name: "FK_Rutas_Recursos",
                        column: x => x.IdRecurso,
                        principalTable: "Recursos",
                        principalColumn: "IdRecurso");
                    table.ForeignKey(
                        name: "FK_Rutas_Usuarios",
                        column: x => x.IdEstudiante,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_IdEstudiante",
                table: "Asignacion",
                column: "IdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_IdRecurso",
                table: "Asignacion",
                column: "IdRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdRecurso1",
                table: "Calificaciones",
                column: "IdRecurso1");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdUsuario",
                table: "Calificaciones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_IdRol",
                table: "Permisos",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_IdCategoria",
                table: "Recursos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_IdProfesor",
                table: "Recursos",
                column: "IdProfesor");

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_IdEstudiante",
                table: "Rutas",
                column: "IdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_IdRecurso",
                table: "Rutas",
                column: "IdRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignacion");

            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Recursos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
