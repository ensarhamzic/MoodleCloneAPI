using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodleCloneAPI.Migrations
{
    /// <inheritdoc />
    public partial class data2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Osobe",
                columns: new[] { "JMBG", "Email", "Ime", "PasswordHash", "PasswordSalt", "Pol", "Prezime", "Username" },
                values: new object[] { "0000000000000", "admin@admin.com", "Admin", new byte[] { 198, 74, 62, 236, 72, 143, 124, 133, 144, 246, 236, 221, 131, 55, 132, 130, 226, 144, 174, 196, 248, 46, 5, 211, 4, 30, 169, 213, 41, 233, 73, 84, 130, 230, 64, 87, 1, 12, 156, 188, 93, 238, 59, 138, 115, 163, 16, 43, 68, 65, 126, 125, 192, 174, 16, 40, 233, 148, 208, 197, 54, 193, 131, 170 }, new byte[] { 100, 211, 9, 93, 128, 8, 155, 49, 223, 8, 22, 158, 221, 119, 38, 102, 135, 176, 62, 60, 12, 86, 143, 214, 181, 88, 43, 193, 185, 6, 210, 245, 55, 251, 66, 226, 137, 195, 240, 173, 72, 203, 98, 206, 138, 131, 14, 84, 188, 142, 0, 208, 75, 58, 140, 211, 17, 59, 133, 39, 123, 92, 97, 124, 160, 220, 124, 99, 99, 25, 148, 133, 248, 175, 49, 212, 21, 129, 205, 100, 173, 196, 132, 96, 109, 224, 36, 151, 27, 223, 223, 213, 155, 243, 153, 98, 233, 235, 234, 43, 8, 31, 86, 244, 179, 237, 42, 117, 74, 5, 129, 121, 194, 180, 70, 125, 82, 39, 215, 42, 119, 232, 18, 231, 51, 249, 179, 127 }, "M", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Administratori",
                columns: new[] { "OsobaJMBG", "Superadmin" },
                values: new object[] { "0000000000000", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administratori",
                keyColumn: "OsobaJMBG",
                keyValue: "0000000000000");

            migrationBuilder.DeleteData(
                table: "Osobe",
                keyColumn: "JMBG",
                keyValue: "0000000000000");
        }
    }
}
