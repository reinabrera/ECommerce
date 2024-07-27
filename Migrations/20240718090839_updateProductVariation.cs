using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class updateProductVariation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_ProductImages_ImageId",
                table: "ProductVariant");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariant_ImageId",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ProductVariant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "ProductVariant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_ImageId",
                table: "ProductVariant",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_ProductImages_ImageId",
                table: "ProductVariant",
                column: "ImageId",
                principalTable: "ProductImages",
                principalColumn: "Id");
        }
    }
}
