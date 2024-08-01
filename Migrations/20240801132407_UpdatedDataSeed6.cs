using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDataSeed6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Women's Shirts" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4494));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Inventory", "IsFeatured", "IsPublished", "ListPrice", "MaxPrice", "MinPrice", "Name", "Overview", "SalePrice", "ShippingFee" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111132"), new DateTime(2024, 8, 1, 21, 24, 6, 464, DateTimeKind.Local).AddTicks(4505), "<p>Since it’s creation lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p><p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident.</p><p>&nbsp;</p><figure class=\"image image_resized\" style=\"width:100%;\"><img style=\"aspect-ratio:1200/598;\" src=\"\\Media\\description-1.jpg\" width=\"1200\" height=\"598\" uploadprocessed=\"true\"></figure><figure class=\"image image_resized image-style-align-left\" style=\"width:49.8%;\"><img style=\"aspect-ratio:600/600;\" src=\"\\Media\\description-2.jpg\" width=\"600\" height=\"600\" uploadprocessed=\"true\"></figure><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p><strong>Ut enim ad minim</strong></p><div class=\"elementor-element elementor-element-dd7a4d1 elementor-widget elementor-widget-text-editor\" style=\"--align-content:initial;--align-items:initial;--align-self:initial;--flex-basis:initial;--flex-direction:initial;--flex-grow:initial;--flex-shrink:initial;--flex-wrap:initial;--gap:initial;--justify-content:initial;--order:initial;--swiper-navigation-size:44px;--swiper-pagination-bullet-horizontal-gap:6px;--swiper-pagination-bullet-size:6px;--swiper-theme-color:#000;--widgets-spacing:20px;-webkit-text-stroke-width:0px;align-content:var(--align-content);align-items:var(--align-items);align-self:var(--align-self);box-sizing:border-box;color:rgb(51, 51, 51);column-gap:50px;columns:1;flex-basis:var(--flex-basis);flex-direction:var(--flex-direction);flex-grow:var(--flex-grow);flex-shrink:var(--flex-shrink);flex-wrap:var(--flex-wrap);font-family:Lato, sans-serif;font-size:16px;font-style:normal;font-variant-caps:normal;font-variant-ligatures:normal;font-weight:400;justify-content:var(--justify-content);letter-spacing:normal;margin-bottom:0px;order:var(--order);orphans:2;position:relative;row-gap:;text-align:start;text-decoration-color:initial;text-decoration-style:initial;text-decoration-thickness:initial;text-indent:0px;text-transform:none;white-space:normal;widows:2;width:400px;word-spacing:0px;\" data-id=\"dd7a4d1\" data-element_type=\"widget\" data-widget_type=\"text-editor.default\"><div class=\"elementor-widget-container\" style=\"box-sizing:border-box;transition:background .3s,border .3s,border-radius .3s,box-shadow .3s,transform var(--e-transform-transition-duration,.4s);\"><p style=\"border-width:0px;box-sizing:border-box;font-size:16px;font-style:inherit;font-weight:inherit;margin:0px 0px 1.6em;outline:0px;padding:0px;vertical-align:baseline;\">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p><div class=\"elementor-element elementor-element-3b3dcbd elementor-widget elementor-widget-heading\" style=\"--align-content:initial;--align-items:initial;--align-self:initial;--flex-basis:initial;--flex-direction:initial;--flex-grow:initial;--flex-shrink:initial;--flex-wrap:initial;--gap:initial;--justify-content:initial;--order:initial;--swiper-navigation-size:44px;--swiper-pagination-bullet-horizontal-gap:6px;--swiper-pagination-bullet-size:6px;--swiper-theme-color:#000;--widgets-spacing:20px;-webkit-text-stroke-width:0px;align-content:var(--align-content);align-items:var(--align-items);align-self:var(--align-self);box-sizing:border-box;color:rgb(51, 51, 51);flex-basis:var(--flex-basis);flex-direction:var(--flex-direction);flex-grow:var(--flex-grow);flex-shrink:var(--flex-shrink);flex-wrap:var(--flex-wrap);font-family:Lato, sans-serif;font-size:16px;font-style:normal;font-variant-caps:normal;font-variant-ligatures:normal;font-weight:400;gap:var(--gap);justify-content:var(--justify-content);letter-spacing:normal;margin-bottom:0px;order:var(--order);orphans:2;position:relative;text-align:start;text-decoration-color:initial;text-decoration-style:initial;text-decoration-thickness:initial;text-indent:0px;text-transform:none;white-space:normal;widows:2;width:400px;word-spacing:0px;\" data-id=\"3b3dcbd\" data-element_type=\"widget\" data-widget_type=\"heading.default\"><div class=\"elementor-widget-container\" style=\"box-sizing:border-box;padding:0px;transition:background .3s,border .3s,border-radius .3s,box-shadow .3s,transform var(--e-transform-transition-duration,.4s);\"><h5 class=\"elementor-heading-title elementor-size-default\" style=\"border-width:0px;box-sizing:border-box;clear:both;color:var(--ast-global-color-2);font-family:Lato, sans-serif;font-size:1.125rem;font-style:inherit;line-height:1.2em;margin:0px;outline:0px;padding:0px;vertical-align:baseline;\"><strong>Quis nostrud</strong></h5></div></div><div class=\"elementor-element elementor-element-153375e elementor-widget elementor-widget-text-editor\" style=\"--align-content:initial;--align-items:initial;--align-self:initial;--flex-basis:initial;--flex-direction:initial;--flex-grow:initial;--flex-shrink:initial;--flex-wrap:initial;--gap:initial;--justify-content:initial;--order:initial;--swiper-navigation-size:44px;--swiper-pagination-bullet-horizontal-gap:6px;--swiper-pagination-bullet-size:6px;--swiper-theme-color:#000;--widgets-spacing:20px;-webkit-text-stroke-width:0px;align-content:var(--align-content);align-items:var(--align-items);align-self:var(--align-self);box-sizing:border-box;color:rgb(51, 51, 51);column-gap:50px;columns:1;flex-basis:var(--flex-basis);flex-direction:var(--flex-direction);flex-grow:var(--flex-grow);flex-shrink:var(--flex-shrink);flex-wrap:var(--flex-wrap);font-family:Lato, sans-serif;font-size:16px;font-style:normal;font-variant-caps:normal;font-variant-ligatures:normal;font-weight:400;justify-content:var(--justify-content);letter-spacing:normal;margin-bottom:0px;order:var(--order);orphans:2;position:relative;row-gap:;text-align:start;text-decoration-color:initial;text-decoration-style:initial;text-decoration-thickness:initial;text-indent:0px;text-transform:none;white-space:normal;widows:2;width:400px;word-spacing:0px;\" data-id=\"153375e\" data-element_type=\"widget\" data-widget_type=\"text-editor.default\"><div class=\"elementor-widget-container\" style=\"box-sizing:border-box;transition:background .3s,border .3s,border-radius .3s,box-shadow .3s,transform var(--e-transform-transition-duration,.4s);\"><p style=\"border-width:0px;box-sizing:border-box;font-size:16px;font-style:inherit;font-weight:inherit;margin:0px 0px 1.6em;outline:0px;padding:0px;vertical-align:baseline;\">Sed do eiusmod tempor incididunt ut labore.</p><div class=\"elementor-element elementor-element-6b6a2a8 elementor-widget elementor-widget-heading\" style=\"--align-content:initial;--align-items:initial;--align-self:initial;--flex-basis:initial;--flex-direction:initial;--flex-grow:initial;--flex-shrink:initial;--flex-wrap:initial;--gap:initial;--justify-content:initial;--order:initial;--swiper-navigation-size:44px;--swiper-pagination-bullet-horizontal-gap:6px;--swiper-pagination-bullet-size:6px;--swiper-theme-color:#000;--widgets-spacing:20px;-webkit-text-stroke-width:0px;align-content:var(--align-content);align-items:var(--align-items);align-self:var(--align-self);box-sizing:border-box;color:rgb(51, 51, 51);flex-basis:var(--flex-basis);flex-direction:var(--flex-direction);flex-grow:var(--flex-grow);flex-shrink:var(--flex-shrink);flex-wrap:var(--flex-wrap);font-family:Lato, sans-serif;font-size:16px;font-style:normal;font-variant-caps:normal;font-variant-ligatures:normal;font-weight:400;gap:var(--gap);justify-content:var(--justify-content);letter-spacing:normal;margin-bottom:0px;order:var(--order);orphans:2;position:relative;text-align:start;text-decoration-color:initial;text-decoration-style:initial;text-decoration-thickness:initial;text-indent:0px;text-transform:none;white-space:normal;widows:2;width:400px;word-spacing:0px;\" data-id=\"6b6a2a8\" data-element_type=\"widget\" data-widget_type=\"heading.default\"><div class=\"elementor-widget-container\" style=\"box-sizing:border-box;padding:0px;transition:background .3s,border .3s,border-radius .3s,box-shadow .3s,transform var(--e-transform-transition-duration,.4s);\"><h5 class=\"elementor-heading-title elementor-size-default\" style=\"border-width:0px;box-sizing:border-box;clear:both;color:var(--ast-global-color-2);font-family:Lato, sans-serif;font-size:1.125rem;font-style:inherit;line-height:1.2em;margin:0px;outline:0px;padding:0px;vertical-align:baseline;\"><strong>Duis aute irure</strong></h5></div></div><div class=\"elementor-element elementor-element-69e7302 elementor-widget elementor-widget-text-editor\" style=\"--align-content:initial;--align-items:initial;--align-self:initial;--flex-basis:initial;--flex-direction:initial;--flex-grow:initial;--flex-shrink:initial;--flex-wrap:initial;--gap:initial;--justify-content:initial;--order:initial;--swiper-navigation-size:44px;--swiper-pagination-bullet-horizontal-gap:6px;--swiper-pagination-bullet-size:6px;--swiper-theme-color:#000;--widgets-spacing:20px;-webkit-text-stroke-width:0px;align-content:var(--align-content);align-items:var(--align-items);align-self:var(--align-self);box-sizing:border-box;color:rgb(51, 51, 51);column-gap:50px;columns:1;flex-basis:var(--flex-basis);flex-direction:var(--flex-direction);flex-grow:var(--flex-grow);flex-shrink:var(--flex-shrink);flex-wrap:var(--flex-wrap);font-family:Lato, sans-serif;font-size:16px;font-style:normal;font-variant-caps:normal;font-variant-ligatures:normal;font-weight:400;justify-content:var(--justify-content);letter-spacing:normal;order:var(--order);orphans:2;position:relative;row-gap:;text-align:start;text-decoration-color:initial;text-decoration-style:initial;text-decoration-thickness:initial;text-indent:0px;text-transform:none;white-space:normal;widows:2;width:400px;word-spacing:0px;\" data-id=\"69e7302\" data-element_type=\"widget\" data-widget_type=\"text-editor.default\"><div class=\"elementor-widget-container\" style=\"box-sizing:border-box;transition:background .3s,border .3s,border-radius .3s,box-shadow .3s,transform var(--e-transform-transition-duration,.4s);\"><p style=\"border-width:0px;box-sizing:border-box;font-size:16px;font-style:inherit;font-weight:inherit;margin:0px 0px 1.6em;outline:0px;padding:0px;vertical-align:baseline;\">Dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.</p></div></div></div></div></div></div><figure class=\"image image_resized image-style-align-right\" style=\"width:49.8%;\"><img style=\"aspect-ratio:600/600;\" src=\"\\Media\\description-3.jpg\" width=\"600\" height=\"600\" uploadprocessed=\"true\"></figure><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p><strong>More about the product</strong></p><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in.</p>", 10, false, true, 25.00m, 25.00m, 25.00m, "Flamingo Tshirt", "Nam nec tellus a odio tincidunt auctor a ornare odio. Sed non mauris vitae erat consequat auctor eu in elit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Mauris in erat justo. Nullam ac urna eu felis dapibus condimentum sit amet a augue. Sed non neque elit sed.", null, null });

            migrationBuilder.InsertData(
                table: "ProductAttributeJoinTable",
                columns: new[] { "Id", "AttributeId", "ProductId" },
                values: new object[,]
                {
                    { 6, 1, new Guid("11111111-1111-1111-1111-111111111132") },
                    { 7, 2, new Guid("11111111-1111-1111-1111-111111111132") }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "Order", "ProductId" },
                values: new object[,]
                {
                    { 48, 10, 1, new Guid("11111111-1111-1111-1111-111111111132") },
                    { 49, 2, 2, new Guid("11111111-1111-1111-1111-111111111132") }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "FileName", "FilePath", "IsFeatured", "IsFromEditor", "ProductId", "SortOrder" },
                values: new object[,]
                {
                    { 33, "tshirt-flamingo-blue-1", "\\ProductImages\\tshirt-flamingo-blue-1.jpg", true, false, new Guid("11111111-1111-1111-1111-111111111132"), 0 },
                    { 34, "tshirt-flamingo-orange-1", "\\ProductImages\\tshirt-flamingo-orange-1.jpg", false, false, new Guid("11111111-1111-1111-1111-111111111132"), 0 },
                    { 35, "tshirt-flamingo-purple-1", "\\ProductImages\\tshirt-flamingo-purple-1.jpg", false, false, new Guid("11111111-1111-1111-1111-111111111132"), 0 },
                    { 36, "tshirt-flamingo-yellow-1", "\\ProductImages\\tshirt-flamingo-yellow-1.jpg", false, false, new Guid("11111111-1111-1111-1111-111111111132"), 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductTermJoinTable",
                columns: new[] { "Id", "ProductId", "TermId" },
                values: new object[,]
                {
                    { 19, new Guid("11111111-1111-1111-1111-111111111132"), 5 },
                    { 20, new Guid("11111111-1111-1111-1111-111111111132"), 7 },
                    { 21, new Guid("11111111-1111-1111-1111-111111111132"), 8 },
                    { 22, new Guid("11111111-1111-1111-1111-111111111132"), 9 },
                    { 23, new Guid("11111111-1111-1111-1111-111111111132"), 11 },
                    { 24, new Guid("11111111-1111-1111-1111-111111111132"), 12 },
                    { 25, new Guid("11111111-1111-1111-1111-111111111132"), 13 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductAttributeJoinTable",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductAttributeJoinTable",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductTermJoinTable",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductTermJoinTable",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductTermJoinTable",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductTermJoinTable",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductTermJoinTable",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductTermJoinTable",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductTermJoinTable",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5532));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111115"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111116"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5539));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111117"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111118"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5545));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111119"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111120"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5553));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111124"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111125"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111126"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111127"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111128"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5573));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111129"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111130"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreatedDate",
                value: new DateTime(2024, 8, 1, 18, 41, 25, 554, DateTimeKind.Local).AddTicks(5580));
        }
    }
}
