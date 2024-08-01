using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProductCategoriesAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 16,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 17,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 18,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 19,
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 20,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Order", "ProductId" },
                values: new object[] { 2, new Guid("11111111-1111-1111-1111-111111111122") });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Order", "ProductId" },
                values: new object[] { 1, new Guid("11111111-1111-1111-1111-111111111122") });

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
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 17, 55, 14, 286, DateTimeKind.Local).AddTicks(7183), true });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId_Order",
                table: "ProductCategories",
                columns: new[] { "ProductId", "Order" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ProductId_Order",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "ProductCategories");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 21,
                column: "ProductId",
                value: new Guid("11111111-1111-1111-1111-111111111121"));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 22,
                column: "ProductId",
                value: new Guid("11111111-1111-1111-1111-111111111121"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5892));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5897), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 16, 33, 54, 969, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");
        }
    }
}
