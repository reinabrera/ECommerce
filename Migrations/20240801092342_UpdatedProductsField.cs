using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProductsField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MaxPrice",
                table: "Products",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinPrice",
                table: "Products",
                type: "decimal(16,2)",
                precision: 16,
                scale: 2,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(428), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(445), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(448), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(450), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(451), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(454), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(456), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(458), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(460), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(462), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(463), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(466), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(467), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(469), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(471), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(472), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(474), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(476), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(478), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(479), null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                columns: new[] { "CreatedDate", "MaxPrice", "MinPrice" },
                values: new object[] { new DateTime(2024, 8, 1, 17, 23, 41, 632, DateTimeKind.Local).AddTicks(483), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinPrice",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(302));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(319));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(323));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(335));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(338));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(343));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(351));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 31, 18, 32, 41, 968, DateTimeKind.Local).AddTicks(356));
        }
    }
}
