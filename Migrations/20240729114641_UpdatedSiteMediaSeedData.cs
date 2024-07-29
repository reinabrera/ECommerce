using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSiteMediaSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 4,
                column: "FilePath",
                value: "\\Media\\logo-1.svg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 5,
                column: "FilePath",
                value: "\\Media\\logo-2.svg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 6,
                column: "FilePath",
                value: "\\Media\\logo-3.svg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 7,
                column: "FilePath",
                value: "\\Media\\logo-4.svg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 8,
                column: "FilePath",
                value: "\\Media\\logo-5.svg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 9,
                column: "FilePath",
                value: "\\Media\\logo-6.svg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 10,
                column: "FilePath",
                value: "\\Media\\logo-7.svg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 11,
                column: "FilePath",
                value: "\\Media\\logo-8.svg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 12,
                column: "FilePath",
                value: "\\Media\\logo-9.svg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 4,
                column: "FilePath",
                value: "\\Media\\logo-1.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 5,
                column: "FilePath",
                value: "\\Media\\logo-2.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 6,
                column: "FilePath",
                value: "\\Media\\logo-3.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 7,
                column: "FilePath",
                value: "\\Media\\logo-4.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 8,
                column: "FilePath",
                value: "\\Media\\logo-5.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 9,
                column: "FilePath",
                value: "\\Media\\logo-6.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 10,
                column: "FilePath",
                value: "\\Media\\logo-7.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 11,
                column: "FilePath",
                value: "\\Media\\logo-8.jpg");

            migrationBuilder.UpdateData(
                table: "SiteMedias",
                keyColumn: "Id",
                keyValue: 12,
                column: "FilePath",
                value: "\\Media\\logo-9.jpg");
        }
    }
}
