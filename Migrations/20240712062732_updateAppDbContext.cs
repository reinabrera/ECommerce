using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class updateAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAdditionalImages_Products_ProductId",
                table: "ProductAdditionalImages");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAdditionalImages_Products_ProductId",
                table: "ProductAdditionalImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAdditionalImages_Products_ProductId",
                table: "ProductAdditionalImages");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAdditionalImages_Products_ProductId",
                table: "ProductAdditionalImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
