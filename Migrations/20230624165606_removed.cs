using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodleCloneAPI.Migrations
{
    /// <inheritdoc />
    public partial class removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Superadmin",
                table: "Administratori");

            migrationBuilder.UpdateData(
                table: "Osobe",
                keyColumn: "JMBG",
                keyValue: "0000000000000",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 207, 221, 205, 80, 209, 198, 200, 38, 5, 103, 111, 109, 184, 159, 91, 197, 200, 172, 215, 37, 170, 65, 155, 121, 49, 80, 0, 48, 207, 132, 146, 85, 3, 30, 17, 32, 156, 157, 69, 81, 69, 137, 153, 122, 9, 238, 128, 207, 104, 221, 173, 183, 46, 186, 97, 155, 19, 126, 175, 124, 220, 234, 218, 123 }, new byte[] { 31, 103, 102, 206, 180, 71, 41, 161, 164, 23, 89, 200, 72, 147, 146, 248, 125, 188, 57, 128, 86, 128, 172, 202, 59, 132, 123, 45, 52, 120, 142, 113, 45, 199, 2, 71, 74, 65, 218, 201, 107, 110, 158, 109, 210, 44, 63, 60, 183, 55, 39, 106, 93, 100, 176, 121, 155, 113, 227, 162, 64, 234, 176, 187, 203, 92, 184, 196, 110, 250, 82, 96, 156, 167, 224, 245, 85, 142, 90, 76, 21, 191, 75, 168, 78, 53, 31, 53, 105, 148, 82, 22, 46, 58, 45, 91, 7, 164, 169, 75, 247, 67, 60, 156, 197, 56, 101, 81, 219, 230, 57, 55, 78, 171, 48, 228, 72, 240, 152, 125, 149, 206, 73, 86, 190, 72, 133, 137 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Superadmin",
                table: "Administratori",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Administratori",
                keyColumn: "OsobaJMBG",
                keyValue: "0000000000000",
                column: "Superadmin",
                value: true);

            migrationBuilder.UpdateData(
                table: "Osobe",
                keyColumn: "JMBG",
                keyValue: "0000000000000",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 198, 74, 62, 236, 72, 143, 124, 133, 144, 246, 236, 221, 131, 55, 132, 130, 226, 144, 174, 196, 248, 46, 5, 211, 4, 30, 169, 213, 41, 233, 73, 84, 130, 230, 64, 87, 1, 12, 156, 188, 93, 238, 59, 138, 115, 163, 16, 43, 68, 65, 126, 125, 192, 174, 16, 40, 233, 148, 208, 197, 54, 193, 131, 170 }, new byte[] { 100, 211, 9, 93, 128, 8, 155, 49, 223, 8, 22, 158, 221, 119, 38, 102, 135, 176, 62, 60, 12, 86, 143, 214, 181, 88, 43, 193, 185, 6, 210, 245, 55, 251, 66, 226, 137, 195, 240, 173, 72, 203, 98, 206, 138, 131, 14, 84, 188, 142, 0, 208, 75, 58, 140, 211, 17, 59, 133, 39, 123, 92, 97, 124, 160, 220, 124, 99, 99, 25, 148, 133, 248, 175, 49, 212, 21, 129, 205, 100, 173, 196, 132, 96, 109, 224, 36, 151, 27, 223, 223, 213, 155, 243, 153, 98, 233, 235, 234, 43, 8, 31, 86, 244, 179, 237, 42, 117, 74, 5, 129, 121, 194, 180, 70, 125, 82, 39, 215, 42, 119, 232, 18, 231, 51, 249, 179, 127 } });
        }
    }
}
