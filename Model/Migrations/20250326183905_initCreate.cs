using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class initCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BENUTZER",
                columns: table => new
                {
                    BENUTZER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BENUTZER_NAME = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PASSWORT = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL_ADDRESSE = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GEBURTSTAG = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PROFIL_BILD = table.Column<byte[]>(type: "longblob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BENUTZER", x => x.BENUTZER_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BUECHER",
                columns: table => new
                {
                    BUCH_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TITEL = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AUTOR = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ERSTER_SATZ = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COVER_URL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ISBN = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUECHER", x => x.BUCH_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BUCHBEZIEHUNG_JT",
                columns: table => new
                {
                    BUCH_ID = table.Column<int>(type: "int", nullable: false),
                    BENUTZER_ID = table.Column<int>(type: "int", nullable: false),
                    STATUS = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ANFANGSDATUM = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUCHBEZIEHUNG_JT", x => new { x.BUCH_ID, x.BENUTZER_ID, x.STATUS });
                    table.ForeignKey(
                        name: "FK_BUCHBEZIEHUNG_JT_BENUTZER_BENUTZER_ID",
                        column: x => x.BENUTZER_ID,
                        principalTable: "BENUTZER",
                        principalColumn: "BENUTZER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BUCHBEZIEHUNG_JT_BUECHER_BUCH_ID",
                        column: x => x.BUCH_ID,
                        principalTable: "BUECHER",
                        principalColumn: "BUCH_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BUCHBEZIEHUNG_JT_BENUTZER_ID",
                table: "BUCHBEZIEHUNG_JT",
                column: "BENUTZER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BUCHBEZIEHUNG_JT");

            migrationBuilder.DropTable(
                name: "BENUTZER");

            migrationBuilder.DropTable(
                name: "BUECHER");
        }
    }
}
