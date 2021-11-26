using Microsoft.EntityFrameworkCore.Migrations;

namespace ConnexioPostgresql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cicle",
                columns: table => new
                {
                    Nom_Cicle = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Cicle_pkey", x => x.Nom_Cicle);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    NIF = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Telèfon = table.Column<string>(type: "character(9)", fixedLength: true, maxLength: 9, nullable: true),
                    Ubicació = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Mail = table.Column<string>(type: "character(50)", fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Empresa_pkey", x => x.NIF);
                });

            migrationBuilder.CreateTable(
                name: "Alumnes",
                columns: table => new
                {
                    DNI = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Nom_Alumne = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Cognom_Alumne = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Tipus_Practica = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Nom_cicle = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Alumnes_pkey", x => x.DNI);
                    table.ForeignKey(
                        name: "Fk_Nom_Cicle",
                        column: x => x.Nom_cicle,
                        principalTable: "Cicle",
                        principalColumn: "Nom_Cicle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuari",
                columns: table => new
                {
                    Nom = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Mail = table.Column<string>(type: "character(50)", fixedLength: true, maxLength: 50, nullable: true),
                    Contrasenya = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Administrador = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Nom_Cicle = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Usuari_pkey", x => x.Nom);
                    table.ForeignKey(
                        name: "Fk_Usuri_Cicle",
                        column: x => x.Nom_Cicle,
                        principalTable: "Cicle",
                        principalColumn: "Nom_Cicle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asociada",
                columns: table => new
                {
                    Cicle_Nom = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Empresa_NIF = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Asociada", x => new { x.Cicle_Nom, x.Empresa_NIF });
                    table.ForeignKey(
                        name: "Fk_Cicle_Nom",
                        column: x => x.Cicle_Nom,
                        principalTable: "Cicle",
                        principalColumn: "Nom_Cicle",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_Empresa_Nif",
                        column: x => x.Empresa_NIF,
                        principalTable: "Empresa",
                        principalColumn: "NIF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacte",
                columns: table => new
                {
                    DNI = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Nom = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Telèfon = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: true),
                    Especialització = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: true),
                    NIF_Empresa = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Contacte_pkey", x => x.DNI);
                    table.ForeignKey(
                        name: "Fk_Nif_Empresa",
                        column: x => x.NIF_Empresa,
                        principalTable: "Empresa",
                        principalColumn: "NIF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pertany",
                columns: table => new
                {
                    Alumnes_DNI = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Asociada_Cicle_Nom = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Asociada_Empresa_NIF = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Pertany", x => new { x.Alumnes_DNI, x.Asociada_Cicle_Nom, x.Asociada_Empresa_NIF });
                    table.ForeignKey(
                        name: "Fk_Alumnes_Dni",
                        column: x => x.Alumnes_DNI,
                        principalTable: "Alumnes",
                        principalColumn: "DNI",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_Asociada_Cicle",
                        columns: x => new { x.Asociada_Cicle_Nom, x.Asociada_Empresa_NIF },
                        principalTable: "Asociada",
                        principalColumns: new[] { "Cicle_Nom", "Empresa_NIF" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cicle_Contacte",
                columns: table => new
                {
                    Cicle_Nom = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Contacte_DNI = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cicle_Contacte", x => new { x.Cicle_Nom, x.Contacte_DNI });
                    table.ForeignKey(
                        name: "Fk_Cicle_Nom",
                        column: x => x.Cicle_Nom,
                        principalTable: "Cicle",
                        principalColumn: "Nom_Cicle",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_Contacte_Dni",
                        column: x => x.Contacte_DNI,
                        principalTable: "Contacte",
                        principalColumn: "DNI",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comunicacions",
                columns: table => new
                {
                    Usuari_Nom = table.Column<string>(type: "character(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Contacte_DNI = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Comunicacions", x => new { x.Usuari_Nom, x.Contacte_DNI });
                    table.ForeignKey(
                        name: "Fk_Dni_Contacte",
                        column: x => x.Contacte_DNI,
                        principalTable: "Contacte",
                        principalColumn: "DNI",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_Nom_Usuari",
                        column: x => x.Usuari_Nom,
                        principalTable: "Usuari",
                        principalColumn: "Nom",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnes_Nom_cicle",
                table: "Alumnes",
                column: "Nom_cicle");

            migrationBuilder.CreateIndex(
                name: "IX_Asociada_Empresa_NIF",
                table: "Asociada",
                column: "Empresa_NIF");

            migrationBuilder.CreateIndex(
                name: "IX_Cicle_Contacte_Contacte_DNI",
                table: "Cicle_Contacte",
                column: "Contacte_DNI");

            migrationBuilder.CreateIndex(
                name: "IX_Comunicacions_Contacte_DNI",
                table: "Comunicacions",
                column: "Contacte_DNI");

            migrationBuilder.CreateIndex(
                name: "IX_Contacte_NIF_Empresa",
                table: "Contacte",
                column: "NIF_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_Pertany_Asociada_Cicle_Nom_Asociada_Empresa_NIF",
                table: "Pertany",
                columns: new[] { "Asociada_Cicle_Nom", "Asociada_Empresa_NIF" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuari_Nom_Cicle",
                table: "Usuari",
                column: "Nom_Cicle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cicle_Contacte");

            migrationBuilder.DropTable(
                name: "Comunicacions");

            migrationBuilder.DropTable(
                name: "Pertany");

            migrationBuilder.DropTable(
                name: "Contacte");

            migrationBuilder.DropTable(
                name: "Usuari");

            migrationBuilder.DropTable(
                name: "Alumnes");

            migrationBuilder.DropTable(
                name: "Asociada");

            migrationBuilder.DropTable(
                name: "Cicle");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
