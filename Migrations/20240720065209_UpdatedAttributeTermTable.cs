using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAttributeTermTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "AttributeTerms");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AttributeTerms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorValue",
                table: "AttributeTerms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorValue",
                table: "AttributeTerms");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AttributeTerms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "AttributeTerms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
