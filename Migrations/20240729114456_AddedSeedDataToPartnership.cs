using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedDataToPartnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnershipLogos");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Partnerships",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SiteMedias",
                columns: new[] { "Id", "FileName", "FilePath" },
                values: new object[,]
                {
                    { 4, "logo-1", "\\Media\\logo-1.jpg" },
                    { 5, "logo-2", "\\Media\\logo-2.jpg" },
                    { 6, "logo-3", "\\Media\\logo-3.jpg" },
                    { 7, "logo-4", "\\Media\\logo-4.jpg" },
                    { 8, "logo-5", "\\Media\\logo-5.jpg" },
                    { 9, "logo-6", "\\Media\\logo-6.jpg" },
                    { 10, "logo-7", "\\Media\\logo-7.jpg" },
                    { 11, "logo-8", "\\Media\\logo-8.jpg" },
                    { 12, "logo-9", "\\Media\\logo-9.jpg" },
                    { 13, "member-1", "\\Media\\member-1.jpg" },
                    { 14, "member-2", "\\Media\\member-2.jpg" },
                    { 15, "member-3", "\\Media\\member-3.jpg" },
                    { 16, "member-4", "\\Media\\member-4.jpg" },
                    { 17, "member-5", "\\Media\\member-5.jpg" },
                    { 18, "member-6", "\\Media\\member-6.jpg" },
                    { 19, "description-1", "\\Media\\description-1.jpg" },
                    { 20, "description-2", "\\Media\\description-2.jpg" },
                    { 21, "description-3", "\\Media\\description-3.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Partnerships",
                columns: new[] { "Id", "CompanyName", "CompanyWebsite", "ImageId" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum", "#", 4 },
                    { 2, "Lorem Ipsum", "#", 5 },
                    { 3, "Lorem Ipsum", "#", 6 },
                    { 4, "Lorem Ipsum", "#", 7 },
                    { 5, "Lorem Ipsum", "#", 8 },
                    { 6, "Lorem Ipsum", "#", 9 },
                    { 7, "Lorem Ipsum", "#", 10 },
                    { 8, "Lorem Ipsum", "#", 11 },
                    { 9, "Lorem Ipsum", "#", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partnerships_ImageId",
                table: "Partnerships",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partnerships_SiteMedias_ImageId",
                table: "Partnerships",
                column: "ImageId",
                principalTable: "SiteMedias",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partnerships_SiteMedias_ImageId",
                table: "Partnerships");

            migrationBuilder.DropIndex(
                name: "IX_Partnerships_ImageId",
                table: "Partnerships");

            migrationBuilder.DeleteData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Partnerships",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Partnerships");

            migrationBuilder.CreateTable(
                name: "PartnershipLogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnershipId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnershipLogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnershipLogos_Partnerships_PartnershipId",
                        column: x => x.PartnershipId,
                        principalTable: "Partnerships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnershipLogos_PartnershipId",
                table: "PartnershipLogos",
                column: "PartnershipId",
                unique: true);
        }
    }
}
