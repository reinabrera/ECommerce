using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedDataToTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "ImageId", "Name", "Position" },
                values: new object[,]
                {
                    { 1, 13, "Harvey Spector", "Founder - CEO" },
                    { 2, 14, "Jessica Pearsonn", "COO" },
                    { 3, 15, "Rachel Zain", "Marketing Head" },
                    { 4, 16, "Luise Litt", "Lead Developer" },
                    { 5, 17, "Katrina Bennett", "Intern Designer" },
                    { 6, 18, "Mike Ross", "Intern Designer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
