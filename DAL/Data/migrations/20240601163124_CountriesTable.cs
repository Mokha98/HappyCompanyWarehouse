using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.data.migrations
{
    /// <inheritdoc />
    public partial class CountriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Warehouses");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Warehouses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 250, 29, 133, 15, 227, 129, 178, 117, 175, 28, 88, 29, 145, 46, 18, 40, 36, 104, 20, 197, 199, 215, 173, 107, 124, 62, 254, 170, 72, 236, 120, 43, 1, 230, 6, 6, 248, 201, 10, 131, 248, 16, 40, 29, 65, 172, 221, 142, 30, 89, 10, 6, 150, 151, 119, 9, 29, 199, 177, 146, 97, 235, 42, 22 }, new byte[] { 89, 146, 92, 253, 80, 216, 62, 247, 125, 249, 176, 162, 190, 156, 218, 95, 110, 101, 79, 101, 139, 246, 37, 255, 58, 198, 17, 132, 133, 40, 37, 132, 50, 40, 106, 253, 211, 14, 30, 219, 176, 171, 8, 198, 8, 88, 3, 244, 72, 170, 172, 140, 246, 13, 144, 251, 105, 96, 62, 147, 99, 78, 184, 149, 74, 94, 209, 12, 64, 96, 36, 162, 249, 255, 76, 164, 78, 180, 209, 240, 71, 173, 199, 161, 125, 56, 199, 102, 104, 210, 211, 86, 238, 130, 84, 27, 136, 4, 249, 41, 91, 146, 196, 144, 249, 233, 176, 105, 103, 193, 59, 154, 4, 65, 134, 64, 36, 69, 116, 202, 255, 24, 233, 95, 45, 227, 190, 254 } });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Jordan" },
                    { 2, "Palestine" },
                    { 3, "Egypt" },
                    { 4, "UAE" },
                    { 5, "Saudi Arabia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_CountryId",
                table: "Warehouses",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Country_CountryId",
                table: "Warehouses",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Country_CountryId",
                table: "Warehouses");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_CountryId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Warehouses");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Warehouses",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 140, 120, 182, 129, 77, 184, 86, 171, 244, 76, 237, 237, 255, 178, 247, 5, 5, 140, 150, 20, 4, 206, 34, 63, 107, 159, 223, 56, 97, 149, 93, 204, 86, 135, 169, 75, 228, 211, 110, 192, 195, 86, 64, 86, 111, 160, 246, 165, 33, 231, 122, 246, 77, 253, 196, 127, 71, 207, 203, 8, 151, 38, 220, 74 }, new byte[] { 166, 114, 176, 149, 93, 11, 157, 67, 205, 131, 137, 22, 205, 86, 0, 57, 202, 208, 234, 210, 57, 47, 95, 167, 149, 111, 152, 146, 35, 224, 162, 6, 192, 73, 139, 9, 40, 137, 242, 90, 39, 59, 247, 29, 175, 253, 206, 48, 244, 95, 96, 241, 52, 30, 120, 31, 36, 162, 241, 69, 251, 178, 24, 61, 223, 236, 87, 0, 188, 172, 35, 165, 73, 75, 2, 182, 42, 153, 230, 154, 161, 131, 147, 175, 201, 194, 1, 32, 113, 3, 56, 208, 21, 206, 125, 29, 180, 190, 192, 238, 93, 87, 212, 207, 87, 235, 97, 185, 201, 111, 89, 152, 42, 72, 186, 242, 143, 145, 164, 12, 150, 33, 185, 8, 197, 86, 165, 150 } });
        }
    }
}
