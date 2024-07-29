using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSiteMediaSeedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 13,
                column: "FilePath",
                value: "\\Media\\member-1.png");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 14,
                column: "FilePath",
                value: "\\Media\\member-2.png");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 15,
                column: "FilePath",
                value: "\\Media\\member-3.png");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 16,
                column: "FilePath",
                value: "\\Media\\member-4.png");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 17,
                column: "FilePath",
                value: "\\Media\\member-5.png");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 18,
                column: "FilePath",
                value: "\\Media\\member-6.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 13,
                column: "FilePath",
                value: "\\Media\\member-1.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 14,
                column: "FilePath",
                value: "\\Media\\member-2.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 15,
                column: "FilePath",
                value: "\\Media\\member-3.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 16,
                column: "FilePath",
                value: "\\Media\\member-4.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 17,
                column: "FilePath",
                value: "\\Media\\member-5.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 18,
                column: "FilePath",
                value: "\\Media\\member-6.jpg");
        }
    }
}
