﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class removeSpecialPromotionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialPromotions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecialPromotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteMediaId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialPromotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialPromotions_SiteMedias_SiteMediaId",
                        column: x => x.SiteMediaId,
                        principalTable: "SiteMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPromotions_SiteMediaId",
                table: "SpecialPromotions",
                column: "SiteMediaId");
        }
    }
}
