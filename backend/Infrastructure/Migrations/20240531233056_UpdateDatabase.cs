using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Recursos",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Rutas_Recursos",
                table: "Rutas");

            migrationBuilder.DropIndex(
                name: "IX_Rutas_IdRecurso",
                table: "Rutas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calificaciones",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_IdRecurso1",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "IdRecurso",
                table: "Rutas");

            migrationBuilder.RenameColumn(
                name: "IdRecurso1",
                table: "Calificaciones",
                newName: "IdCalificacion");

            migrationBuilder.AddColumn<string>(
                name: "NombreRuta",
                table: "Rutas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duracion",
                table: "Recursos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Recursos",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdRecurso",
                table: "Calificaciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "IdCalificacion",
                table: "Calificaciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calificaciones",
                table: "Calificaciones",
                column: "IdCalificacion");

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    IdModulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRecurso = table.Column<int>(type: "int", nullable: false),
                    NombreModulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URLModulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.IdModulo);
                    table.ForeignKey(
                        name: "FK_Modulos_Recursos",
                        column: x => x.IdRecurso,
                        principalTable: "Recursos",
                        principalColumn: "IdRecurso");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdRecurso",
                table: "Calificaciones",
                column: "IdRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_IdRecurso",
                table: "Modulos",
                column: "IdRecurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Recursos",
                table: "Calificaciones",
                column: "IdRecurso",
                principalTable: "Recursos",
                principalColumn: "IdRecurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Recursos",
                table: "Calificaciones");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calificaciones",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_IdRecurso",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "NombreRuta",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Recursos");

            migrationBuilder.RenameColumn(
                name: "IdCalificacion",
                table: "Calificaciones",
                newName: "IdRecurso1");

            migrationBuilder.AddColumn<int>(
                name: "IdRecurso",
                table: "Rutas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdRecurso",
                table: "Calificaciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "IdRecurso1",
                table: "Calificaciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calificaciones",
                table: "Calificaciones",
                column: "IdRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_IdRecurso",
                table: "Rutas",
                column: "IdRecurso");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdRecurso1",
                table: "Calificaciones",
                column: "IdRecurso1");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Recursos",
                table: "Calificaciones",
                column: "IdRecurso1",
                principalTable: "Recursos",
                principalColumn: "IdRecurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutas_Recursos",
                table: "Rutas",
                column: "IdRecurso",
                principalTable: "Recursos",
                principalColumn: "IdRecurso");
        }
    }
}
