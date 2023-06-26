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
                values: new object[] { "0000000000000", "admin@admin.com", "Admin", new byte[] { 177, 113, 245, 25, 191, 56, 197, 90, 95, 14, 131, 148, 18, 111, 183, 115, 40, 31, 147, 46, 77, 211, 57, 111, 162, 233, 45, 126, 194, 129, 179, 36, 37, 47, 172, 31, 149, 166, 84, 199, 0, 217, 18, 65, 168, 130, 117, 94, 81, 34, 1, 125, 223, 198, 205, 240, 77, 62, 43, 234, 242, 100, 175, 29 }, new byte[] { 97, 22, 231, 20, 217, 41, 178, 156, 39, 217, 8, 55, 79, 111, 84, 26, 233, 254, 152, 184, 56, 227, 233, 188, 136, 190, 128, 32, 49, 226, 226, 114, 17, 203, 247, 230, 197, 134, 105, 146, 48, 44, 227, 77, 174, 226, 117, 208, 139, 217, 101, 176, 87, 252, 101, 209, 42, 181, 46, 29, 223, 191, 237, 202, 74, 131, 212, 0, 153, 178, 88, 3, 129, 194, 164, 41, 50, 119, 177, 40, 136, 160, 42, 238, 252, 7, 237, 59, 34, 226, 199, 88, 130, 251, 131, 53, 8, 52, 127, 30, 150, 192, 241, 18, 28, 229, 227, 243, 118, 255, 157, 146, 31, 55, 252, 142, 47, 108, 131, 191, 26, 92, 145, 136, 61, 236, 39, 114 }, "M", "Admin", "admin" });

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
