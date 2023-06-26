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
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NastavnikJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
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
                        name: "FK_Materijali_Nastavnici_NastavnikJMBG",
                        column: x => x.NastavnikJMBG,
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
                    StudentJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    MaterijalId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_StudentiMaterijali_Studenti_StudentJMBG",
                        column: x => x.StudentJMBG,
                        principalTable: "Studenti",
                        principalColumn: "OsobaJMBG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentiObavestenja",
                columns: table => new
                {
                    StudentJMBG = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    ObavestenjeId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_StudentiObavestenja_Studenti_StudentJMBG",
                        column: x => x.StudentJMBG,
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
                values: new object[] { "0000000000000", "admin@admin.com", "Admin", new byte[] { 6, 66, 0, 3, 75, 58, 94, 155, 135, 216, 139, 126, 5, 165, 98, 42, 234, 89, 131, 121, 42, 209, 163, 30, 31, 97, 128, 169, 60, 235, 11, 125, 154, 98, 73, 83, 79, 240, 137, 28, 62, 244, 51, 109, 181, 69, 143, 164, 249, 83, 170, 203, 13, 89, 31, 79, 146, 255, 218, 137, 214, 15, 205, 158 }, new byte[] { 104, 75, 233, 219, 249, 85, 125, 126, 21, 251, 235, 172, 187, 27, 209, 72, 43, 20, 225, 24, 29, 144, 82, 164, 72, 4, 173, 69, 138, 39, 27, 78, 180, 98, 87, 79, 217, 87, 1, 187, 255, 13, 37, 110, 241, 48, 220, 43, 160, 153, 235, 105, 197, 200, 146, 15, 54, 174, 153, 156, 232, 60, 46, 64, 197, 137, 3, 176, 136, 176, 177, 134, 34, 54, 23, 5, 16, 12, 197, 47, 6, 5, 95, 38, 24, 160, 44, 66, 246, 24, 40, 84, 59, 33, 110, 92, 203, 218, 191, 10, 2, 158, 245, 154, 199, 185, 29, 162, 80, 180, 116, 209, 154, 105, 27, 44, 110, 167, 168, 207, 231, 150, 48, 173, 32, 130, 116, 134 }, "M", "Admin", "admin" });

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
                name: "IX_Materijali_NastavnikJMBG",
                table: "Materijali",
                column: "NastavnikJMBG");

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
                name: "IX_StudentiObavestenja_ObavestenjeId",
                table: "StudentiObavestenja",
                column: "ObavestenjeId");

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
