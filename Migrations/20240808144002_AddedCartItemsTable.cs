using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class AddedCartItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VariantId = table.Column<int>(type: "int", nullable: true),
                    ItemCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Variations_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variations",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 8, 22, 40, 1, 691, DateTimeKind.Local).AddTicks(1455));

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_VariantId",
                table: "CartItems",
                column: "VariantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

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
    }
}
