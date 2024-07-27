using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class updatedProductVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Variations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variations_ImageId",
                table: "Variations",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Variations_ProductImages_ImageId",
                table: "Variations",
                column: "ImageId",
                principalTable: "ProductImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variations_ProductImages_ImageId",
                table: "Variations");

            migrationBuilder.DropIndex(
                name: "IX_Variations_ImageId",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Variations");
        }
    }
}
