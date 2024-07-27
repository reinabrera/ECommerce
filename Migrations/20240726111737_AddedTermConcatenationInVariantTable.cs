using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class AddedTermConcatenationInVariantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Variations_ProductId",
                table: "Variations");

            migrationBuilder.AddColumn<string>(
                name: "TermsConcatenated",
                table: "Variations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Variations_ProductId_TermsConcatenated",
                table: "Variations",
                columns: new[] { "ProductId", "TermsConcatenated" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Variations_ProductId_TermsConcatenated",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "TermsConcatenated",
                table: "Variations");

            migrationBuilder.CreateIndex(
                name: "IX_Variations_ProductId",
                table: "Variations",
                column: "ProductId");
        }
    }
}
