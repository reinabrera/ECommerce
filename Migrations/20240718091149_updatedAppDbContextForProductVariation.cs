using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class updatedAppDbContextForProductVariation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeTerm_ProductAttribute_AttributeId",
                table: "AttributeTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_AttributeTerm_TermId",
                table: "ProductVariant");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_Products_ProductId",
                table: "ProductVariant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductVariant",
                table: "ProductVariant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttributeTerm",
                table: "AttributeTerm");

            migrationBuilder.RenameTable(
                name: "ProductVariant",
                newName: "Variations");

            migrationBuilder.RenameTable(
                name: "AttributeTerm",
                newName: "AttributeTerms");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariant_TermId",
                table: "Variations",
                newName: "IX_Variations_TermId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariant_ProductId",
                table: "Variations",
                newName: "IX_Variations_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeTerm_AttributeId",
                table: "AttributeTerms",
                newName: "IX_AttributeTerms_AttributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variations",
                table: "Variations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttributeTerms",
                table: "AttributeTerms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeTerms_ProductAttribute_AttributeId",
                table: "AttributeTerms",
                column: "AttributeId",
                principalTable: "ProductAttribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Variations_AttributeTerms_TermId",
                table: "Variations",
                column: "TermId",
                principalTable: "AttributeTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Variations_Products_ProductId",
                table: "Variations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeTerms_ProductAttribute_AttributeId",
                table: "AttributeTerms");

            migrationBuilder.DropForeignKey(
                name: "FK_Variations_AttributeTerms_TermId",
                table: "Variations");

            migrationBuilder.DropForeignKey(
                name: "FK_Variations_Products_ProductId",
                table: "Variations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variations",
                table: "Variations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttributeTerms",
                table: "AttributeTerms");

            migrationBuilder.RenameTable(
                name: "Variations",
                newName: "ProductVariant");

            migrationBuilder.RenameTable(
                name: "AttributeTerms",
                newName: "AttributeTerm");

            migrationBuilder.RenameIndex(
                name: "IX_Variations_TermId",
                table: "ProductVariant",
                newName: "IX_ProductVariant_TermId");

            migrationBuilder.RenameIndex(
                name: "IX_Variations_ProductId",
                table: "ProductVariant",
                newName: "IX_ProductVariant_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeTerms_AttributeId",
                table: "AttributeTerm",
                newName: "IX_AttributeTerm_AttributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductVariant",
                table: "ProductVariant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttributeTerm",
                table: "AttributeTerm",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeTerm_ProductAttribute_AttributeId",
                table: "AttributeTerm",
                column: "AttributeId",
                principalTable: "ProductAttribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_AttributeTerm_TermId",
                table: "ProductVariant",
                column: "TermId",
                principalTable: "AttributeTerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_Products_ProductId",
                table: "ProductVariant",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
