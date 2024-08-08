using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class updatedAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2244));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2257));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2265));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2304));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 15, 3, 48, 365, DateTimeKind.Local).AddTicks(2306));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6218));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6228));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6231));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6234));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 3, 13, 26, 31, 458, DateTimeKind.Local).AddTicks(6273));
        }
    }
}
