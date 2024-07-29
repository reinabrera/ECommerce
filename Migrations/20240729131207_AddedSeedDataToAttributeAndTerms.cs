using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedDataToAttributeAndTerms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Color", 1 },
                    { 2, "Size", 0 }
                });

            migrationBuilder.InsertData(
                table: "AttributeTerms",
                columns: new[] { "Id", "AttributeId", "ColorValue", "Name" },
                values: new object[,]
                {
                    { 1, 1, "#000000", "Black" },
                    { 2, 1, "#aa7627", "Brown" },
                    { 3, 1, "#ce592f", "Red" },
                    { 4, 1, "#1fb1c1", "Aqua" },
                    { 5, 1, "#1e73be", "Blue" },
                    { 6, 1, "#81d742", "Green" },
                    { 7, 1, "#f49922", "Orange" },
                    { 8, 1, "#ce25e8", "Purple" },
                    { 9, 1, "#eac820", "Yellow" },
                    { 10, 1, "#ffffff", "White" },
                    { 11, 2, null, "S" },
                    { 12, 2, null, "M" },
                    { 13, 2, null, "L" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AttributeTerms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
