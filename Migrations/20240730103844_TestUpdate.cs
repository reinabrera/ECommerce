using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class TestUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9820));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9872));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9874));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9881));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7166));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7188));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7194));
        }
    }
}
