using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class addedTermVariationJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variations_AttributeTerms_TermId",
                table: "Variations");

            migrationBuilder.DropIndex(
                name: "IX_Variations_TermId",
                table: "Variations");

            migrationBuilder.DropColumn(
                name: "TermId",
                table: "Variations");

            migrationBuilder.CreateTable(
                name: "TermVariation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TermId = table.Column<int>(type: "int", nullable: false),
                    VariantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermVariation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermVariation_AttributeTerms_TermId",
                        column: x => x.TermId,
                        principalTable: "AttributeTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TermVariation_Variations_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TermVariation_TermId",
                table: "TermVariation",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_TermVariation_VariantId",
                table: "TermVariation",
                column: "VariantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TermVariation");

            migrationBuilder.AddColumn<int>(
                name: "TermId",
                table: "Variations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Variations_TermId",
                table: "Variations",
                column: "TermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Variations_AttributeTerms_TermId",
                table: "Variations",
                column: "TermId",
                principalTable: "AttributeTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
