using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsFeaturedFieldToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8212), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8226), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8228), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8229), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8231), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8232), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8251), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8253), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8254), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8256), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8257), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                columns: new[] { "CreatedDate", "IsFeatured" },
                values: new object[] { new DateTime(2024, 7, 30, 16, 19, 58, 927, DateTimeKind.Local).AddTicks(8259), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3772));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 15, 16, 10, 647, DateTimeKind.Local).AddTicks(3780));
        }
    }
}
