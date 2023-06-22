using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoodleCloneAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osobe",
                columns: table => new
                {
                    JMBG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pol = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobe", x => x.JMBG);
                });

            migrationBuilder.CreateTable(
                name: "Smerovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smerovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zvanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zvanja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administratori",
                columns: table => new
                {
                    OsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Superadmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratori", x => x.OsobaJMBG);
                    table.ForeignKey(
                        name: "FK_Administratori_Osobe_OsobaJMBG",
                        column: x => x.OsobaJMBG,
                        principalTable: "Osobe",
                        principalColumn: "JMBG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nastavnici",
                columns: table => new
                {
                    OsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GodineRadnogStaza = table.Column<int>(type: "int", nullable: false),
                    ZvanjeId = table.Column<int>(type: "int", nullable: false),
                    TipId = table.Column<int>(type: "int", nullable: false),
                    Verifikovan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nastavnici", x => x.OsobaJMBG);
                    table.ForeignKey(
                        name: "FK_Nastavnici_Osobe_OsobaJMBG",
                        column: x => x.OsobaJMBG,
                        principalTable: "Osobe",
                        principalColumn: "JMBG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nastavnici_Tipovi_TipId",
                        column: x => x.TipId,
                        principalTable: "Tipovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nastavnici_Zvanja_ZvanjeId",
                        column: x => x.ZvanjeId,
                        principalTable: "Zvanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kursevi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HronoloskiMod = table.Column<bool>(type: "bit", nullable: false),
                    SmerId = table.Column<int>(type: "int", nullable: false),
                    ProfesorJMBG = table.Column<int>(type: "int", nullable: false),
                    ProfesorOsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    AsistentJMBG = table.Column<int>(type: "int", nullable: false),
                    AsistentOsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kursevi_Nastavnici_AsistentOsobaJMBG",
                        column: x => x.AsistentOsobaJMBG,
                        principalTable: "Nastavnici",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kursevi_Nastavnici_ProfesorOsobaJMBG",
                        column: x => x.ProfesorOsobaJMBG,
                        principalTable: "Nastavnici",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kursevi_Smerovi_SmerId",
                        column: x => x.SmerId,
                        principalTable: "Smerovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materijali",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NastavnikJMBG = table.Column<int>(type: "int", nullable: false),
                    NastavnikOsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materijali", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materijali_Kursevi_KursId",
                        column: x => x.KursId,
                        principalTable: "Kursevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materijali_Nastavnici_NastavnikOsobaJMBG",
                        column: x => x.NastavnikOsobaJMBG,
                        principalTable: "Nastavnici",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obavestenja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NastavnikJMBG = table.Column<int>(type: "int", nullable: false),
                    NastavnikOsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavestenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obavestenja_Kursevi_KursId",
                        column: x => x.KursId,
                        principalTable: "Kursevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obavestenja_Nastavnici_NastavnikOsobaJMBG",
                        column: x => x.NastavnikOsobaJMBG,
                        principalTable: "Nastavnici",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    OsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: true),
                    SmerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.OsobaJMBG);
                    table.ForeignKey(
                        name: "FK_Studenti_Kursevi_KursId",
                        column: x => x.KursId,
                        principalTable: "Kursevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Studenti_Osobe_OsobaJMBG",
                        column: x => x.OsobaJMBG,
                        principalTable: "Osobe",
                        principalColumn: "JMBG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Studenti_Smerovi_SmerId",
                        column: x => x.SmerId,
                        principalTable: "Smerovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrijaveKurseva",
                columns: table => new
                {
                    StudentJMBG = table.Column<int>(type: "int", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    StudentOsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    NaCekanju = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijaveKurseva", x => new { x.StudentJMBG, x.KursId });
                    table.ForeignKey(
                        name: "FK_PrijaveKurseva_Kursevi_KursId",
                        column: x => x.KursId,
                        principalTable: "Kursevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrijaveKurseva_Studenti_StudentOsobaJMBG",
                        column: x => x.StudentOsobaJMBG,
                        principalTable: "Studenti",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentiMaterijali",
                columns: table => new
                {
                    StudentJMBG = table.Column<int>(type: "int", nullable: false),
                    MaterijalId = table.Column<int>(type: "int", nullable: false),
                    StudentOsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentiMaterijali", x => new { x.StudentJMBG, x.MaterijalId });
                    table.ForeignKey(
                        name: "FK_StudentiMaterijali_Materijali_MaterijalId",
                        column: x => x.MaterijalId,
                        principalTable: "Materijali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentiMaterijali_Studenti_StudentOsobaJMBG",
                        column: x => x.StudentOsobaJMBG,
                        principalTable: "Studenti",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentiObavestenja",
                columns: table => new
                {
                    StudentJMBG = table.Column<int>(type: "int", nullable: false),
                    ObavestenjeId = table.Column<int>(type: "int", nullable: false),
                    StudentOsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentiObavestenja", x => new { x.StudentJMBG, x.ObavestenjeId });
                    table.ForeignKey(
                        name: "FK_StudentiObavestenja_Obavestenja_ObavestenjeId",
                        column: x => x.ObavestenjeId,
                        principalTable: "Obavestenja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentiObavestenja_Studenti_StudentOsobaJMBG",
                        column: x => x.StudentOsobaJMBG,
                        principalTable: "Studenti",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentiSmerovi",
                columns: table => new
                {
                    StudentJMBG = table.Column<int>(type: "int", nullable: false),
                    SmerId = table.Column<int>(type: "int", nullable: false),
                    StudentOsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    BrojIndeksa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentiSmerovi", x => new { x.StudentJMBG, x.SmerId });
                    table.ForeignKey(
                        name: "FK_StudentiSmerovi_Smerovi_SmerId",
                        column: x => x.SmerId,
                        principalTable: "Smerovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentiSmerovi_Studenti_StudentOsobaJMBG",
                        column: x => x.StudentOsobaJMBG,
                        principalTable: "Studenti",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tipovi",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Profesor" },
                    { 2, "Asistent" }
                });

            migrationBuilder.InsertData(
                table: "Zvanja",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Redovni profesor" },
                    { 2, "Vanredni profesor" },
                    { 3, "Docent" },
                    { 5, "Saradnik u nastavi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kursevi_AsistentOsobaJMBG",
                table: "Kursevi",
                column: "AsistentOsobaJMBG");

            migrationBuilder.CreateIndex(
                name: "IX_Kursevi_ProfesorOsobaJMBG",
                table: "Kursevi",
                column: "ProfesorOsobaJMBG");

            migrationBuilder.CreateIndex(
                name: "IX_Kursevi_SmerId",
                table: "Kursevi",
                column: "SmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Materijali_KursId",
                table: "Materijali",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Materijali_NastavnikOsobaJMBG",
                table: "Materijali",
                column: "NastavnikOsobaJMBG");

            migrationBuilder.CreateIndex(
                name: "IX_Nastavnici_TipId",
                table: "Nastavnici",
                column: "TipId");

            migrationBuilder.CreateIndex(
                name: "IX_Nastavnici_ZvanjeId",
                table: "Nastavnici",
                column: "ZvanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavestenja_KursId",
                table: "Obavestenja",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavestenja_NastavnikOsobaJMBG",
                table: "Obavestenja",
                column: "NastavnikOsobaJMBG");

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_Email",
                table: "Osobe",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_Username",
                table: "Osobe",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrijaveKurseva_KursId",
                table: "PrijaveKurseva",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijaveKurseva_StudentOsobaJMBG",
                table: "PrijaveKurseva",
                column: "StudentOsobaJMBG");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_KursId",
                table: "Studenti",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_SmerId",
                table: "Studenti",
                column: "SmerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiMaterijali_MaterijalId",
                table: "StudentiMaterijali",
                column: "MaterijalId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiMaterijali_StudentOsobaJMBG",
                table: "StudentiMaterijali",
                column: "StudentOsobaJMBG");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiObavestenja_ObavestenjeId",
                table: "StudentiObavestenja",
                column: "ObavestenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiObavestenja_StudentOsobaJMBG",
                table: "StudentiObavestenja",
                column: "StudentOsobaJMBG");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiSmerovi_SmerId",
                table: "StudentiSmerovi",
                column: "SmerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiSmerovi_StudentOsobaJMBG",
                table: "StudentiSmerovi",
                column: "StudentOsobaJMBG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administratori");

            migrationBuilder.DropTable(
                name: "PrijaveKurseva");

            migrationBuilder.DropTable(
                name: "StudentiMaterijali");

            migrationBuilder.DropTable(
                name: "StudentiObavestenja");

            migrationBuilder.DropTable(
                name: "StudentiSmerovi");

            migrationBuilder.DropTable(
                name: "Materijali");

            migrationBuilder.DropTable(
                name: "Obavestenja");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Kursevi");

            migrationBuilder.DropTable(
                name: "Nastavnici");

            migrationBuilder.DropTable(
                name: "Smerovi");

            migrationBuilder.DropTable(
                name: "Osobe");

            migrationBuilder.DropTable(
                name: "Tipovi");

            migrationBuilder.DropTable(
                name: "Zvanja");
        }
    }
}
