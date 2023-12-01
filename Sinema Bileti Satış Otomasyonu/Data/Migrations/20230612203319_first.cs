using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinema_Bileti_Satış_Otomasyonu.Data.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmDetaylars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Film_ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Film_aciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmResim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmDetaylars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Koltuks",
                columns: table => new
                {
                    KoltukID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KoltukNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Satir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sutun = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koltuks", x => x.KoltukID);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Koltukno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datetopresent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmDetaylarId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervasyons_FilmDetaylars_FilmDetaylarId",
                        column: x => x.FilmDetaylarId,
                        principalTable: "FilmDetaylars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seans",
                columns: table => new
                {
                    SeansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmSeans = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmDetaylarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seans", x => x.SeansId);
                    table.ForeignKey(
                        name: "FK_Seans_FilmDetaylars_FilmDetaylarId",
                        column: x => x.FilmDetaylarId,
                        principalTable: "FilmDetaylars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Koltukno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    SeansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Carts_Seans_SeansId",
                        column: x => x.SeansId,
                        principalTable: "Seans",
                        principalColumn: "SeansId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeansKoltuks",
                columns: table => new
                {
                    SeansKoltukID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeansID = table.Column<int>(type: "int", nullable: false),
                    KoltukID = table.Column<int>(type: "int", nullable: false),
                    Dolu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeansKoltuks", x => x.SeansKoltukID);
                    table.ForeignKey(
                        name: "FK_SeansKoltuks_Koltuks_KoltukID",
                        column: x => x.KoltukID,
                        principalTable: "Koltuks",
                        principalColumn: "KoltukID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeansKoltuks_Seans_SeansID",
                        column: x => x.SeansID,
                        principalTable: "Seans",
                        principalColumn: "SeansId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeansKoltukId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilets_SeansKoltuks_SeansKoltukId",
                        column: x => x.SeansKoltukId,
                        principalTable: "SeansKoltuks",
                        principalColumn: "SeansKoltukID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilets_SeansKoltukId",
                table: "Bilets",
                column: "SeansKoltukId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilets_UserId",
                table: "Bilets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_SeansId",
                table: "Carts",
                column: "SeansId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyons_FilmDetaylarId",
                table: "Rezervasyons",
                column: "FilmDetaylarId");

            migrationBuilder.CreateIndex(
                name: "IX_Seans_FilmDetaylarId",
                table: "Seans",
                column: "FilmDetaylarId");

            migrationBuilder.CreateIndex(
                name: "IX_SeansKoltuks_KoltukID",
                table: "SeansKoltuks",
                column: "KoltukID");

            migrationBuilder.CreateIndex(
                name: "IX_SeansKoltuks_SeansID",
                table: "SeansKoltuks",
                column: "SeansID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilets");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Rezervasyons");

            migrationBuilder.DropTable(
                name: "SeansKoltuks");

            migrationBuilder.DropTable(
                name: "Koltuks");

            migrationBuilder.DropTable(
                name: "Seans");

            migrationBuilder.DropTable(
                name: "FilmDetaylars");
        }
    }
}
