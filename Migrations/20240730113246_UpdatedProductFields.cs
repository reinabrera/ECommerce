using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProductFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SalePrice",
                table: "Variations",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ListPrice",
                table: "Variations",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ShippingFee",
                table: "Products",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SalePrice",
                table: "Products",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ListPrice",
                table: "Products",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(294), 150.00m, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(309), 150.00m, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(311), 150.00m, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(313), 150.00m, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(315), 150.00m, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(317), 150.00m, 130.00m, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(319), 150.00m, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(321), 40.00m, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(322), 150.00m, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(324), 150.00m, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(327), 100.00m, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 19, 32, 46, 56, DateTimeKind.Local).AddTicks(328), 150.00m, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SalePrice",
                table: "Variations",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ListPrice",
                table: "Variations",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShippingFee",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalePrice",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ListPrice",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9820), 150, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9833), 150, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9835), 150, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9837), 150, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9869), 150, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9871), 150, 130, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9872), 150, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9874), 40, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9876), 150, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9878), 150, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9879), 100, null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                columns: new[] { "CreatedDate", "ListPrice", "SalePrice", "ShippingFee" },
                values: new object[] { new DateTime(2024, 7, 30, 18, 38, 43, 433, DateTimeKind.Local).AddTicks(9881), 150, null, null });
        }
    }
}
