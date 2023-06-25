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
                    OsobaJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false)
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
                    ProfesorJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    AsistentJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursevi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kursevi_Nastavnici_AsistentJMBG",
                        column: x => x.AsistentJMBG,
                        principalTable: "Nastavnici",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kursevi_Nastavnici_ProfesorJMBG",
                        column: x => x.ProfesorJMBG,
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
                    NastavnikJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
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
                        name: "FK_Obavestenja_Nastavnici_NastavnikJMBG",
                        column: x => x.NastavnikJMBG,
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
                    StudentJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_PrijaveKurseva_Studenti_StudentJMBG",
                        column: x => x.StudentJMBG,
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
                    StudentJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    SmerId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_StudentiSmerovi_Studenti_StudentJMBG",
                        column: x => x.StudentJMBG,
                        principalTable: "Studenti",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Osobe",
                columns: new[] { "JMBG", "Email", "Ime", "PasswordHash", "PasswordSalt", "Pol", "Prezime", "Username" },
                values: new object[] { "0000000000000", "admin@admin.com", "Admin", new byte[] { 38, 172, 55, 118, 2, 88, 111, 106, 126, 89, 224, 119, 99, 239, 54, 99, 34, 94, 57, 69, 249, 93, 124, 40, 90, 160, 189, 202, 218, 1, 221, 165, 143, 109, 22, 25, 114, 124, 43, 224, 128, 182, 61, 26, 42, 71, 1, 159, 100, 129, 75, 99, 55, 119, 227, 143, 189, 41, 41, 86, 21, 122, 142, 56 }, new byte[] { 70, 48, 97, 91, 105, 107, 186, 223, 45, 176, 220, 14, 74, 213, 27, 168, 69, 175, 254, 58, 100, 248, 167, 214, 198, 56, 10, 125, 72, 4, 83, 30, 88, 206, 37, 50, 194, 153, 232, 50, 33, 237, 226, 74, 213, 249, 179, 112, 129, 89, 193, 169, 187, 133, 93, 58, 244, 61, 108, 216, 46, 56, 93, 103, 123, 162, 42, 239, 186, 178, 83, 33, 215, 80, 114, 1, 215, 102, 60, 22, 196, 136, 144, 12, 56, 95, 122, 177, 111, 175, 32, 205, 249, 202, 141, 238, 109, 3, 113, 15, 114, 68, 96, 9, 187, 131, 68, 26, 118, 198, 231, 141, 131, 99, 123, 206, 173, 144, 59, 54, 107, 44, 160, 19, 186, 251, 7, 230 }, "M", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Smerovi",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Softversko inzenjerstvo" },
                    { 2, "Racunarska tehnika" },
                    { 3, "Matematika" },
                    { 4, "Ekonomija" },
                    { 5, "Pravo" }
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

            migrationBuilder.InsertData(
                table: "Administratori",
                column: "OsobaJMBG",
                value: "0000000000000");

            migrationBuilder.CreateIndex(
                name: "IX_Kursevi_AsistentJMBG",
                table: "Kursevi",
                column: "AsistentJMBG");

            migrationBuilder.CreateIndex(
                name: "IX_Kursevi_ProfesorJMBG",
                table: "Kursevi",
                column: "ProfesorJMBG");

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
                name: "IX_Obavestenja_NastavnikJMBG",
                table: "Obavestenja",
                column: "NastavnikJMBG");

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
