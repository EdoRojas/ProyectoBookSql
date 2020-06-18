using Microsoft.EntityFrameworkCore.Migrations;

namespace BookWeb.Data.Migrations
{
    public partial class cargainicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Idcategorias = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Idpadre = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Idcategorias);
                    table.ForeignKey(
                        name: "FK_Categorias_Categorias_Idpadre",
                        column: x => x.Idpadre,
                        principalTable: "Categorias",
                        principalColumn: "Idcategorias",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "perfiles",
                columns: table => new
                {
                    Idperfil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfiles", x => x.Idperfil);
                });

            migrationBuilder.CreateTable(
                name: "rubros",
                columns: table => new
                {
                    Idrubros = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rubros", x => x.Idrubros);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Idslider = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Urlimagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Idslider);
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Nombredescripcion = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: true),
                    Precio = table.Column<double>(nullable: true),
                    Urlimagen = table.Column<string>(nullable: true),
                    Idcategoria = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Inventario_Categorias_Idcategoria",
                        column: x => x.Idcategoria,
                        principalTable: "Categorias",
                        principalColumn: "Idcategorias",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    Idempleados = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apa = table.Column<string>(nullable: true),
                    Ama = table.Column<string>(nullable: true),
                    Idperfiles = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.Idempleados);
                    table.ForeignKey(
                        name: "FK_empleados_perfiles_Idperfiles",
                        column: x => x.Idperfiles,
                        principalTable: "perfiles",
                        principalColumn: "Idperfil",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "empresas",
                columns: table => new
                {
                    idempresa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Urlimagen = table.Column<string>(nullable: true),
                    Idrubro = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresas", x => x.idempresa);
                    table.ForeignKey(
                        name: "FK_empresas_rubros_Idrubro",
                        column: x => x.Idrubro,
                        principalTable: "rubros",
                        principalColumn: "Idrubros",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Idpadre",
                table: "Categorias",
                column: "Idpadre");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_Idperfiles",
                table: "empleados",
                column: "Idperfiles");

            migrationBuilder.CreateIndex(
                name: "IX_empresas_Idrubro",
                table: "empresas",
                column: "Idrubro");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_Idcategoria",
                table: "Inventario",
                column: "Idcategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "empresas");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "perfiles");

            migrationBuilder.DropTable(
                name: "rubros");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
