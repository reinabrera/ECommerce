using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce2.Migrations
{
    /// <inheritdoc />
    public partial class AddedTestSeedDataForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Inventory", "IsPublished", "ListPrice", "Name", "Overview", "SalePrice", "ShippingFee" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 7, 30, 14, 31, 40, 79, DateTimeKind.Local).AddTicks(6586), "<p>Since it’s creation lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p><p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident.</p><p>&nbsp;</p><figure class=\"image image_resized\" style=\"width:100%;\"><img style=\"aspect-ratio:1200/598;\" src=\"\\ProductImages\\62b39bef-10a0-4bf0-8caf-d640475c8403.jpg\" width=\"1200\" height=\"598\" uploadprocessed=\"true\"></figure><figure class=\"image image_resized image-style-align-left\" style=\"width:49.8%;\"><img style=\"aspect-ratio:600/600;\" src=\"\\ProductImages\\b641c4c8-f497-4443-b488-a77a9ca5f7c3.jpg\" width=\"600\" height=\"600\" uploadprocessed=\"true\"></figure><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p><strong>Ut enim ad minim</strong></p><div class=\"elementor-element elementor-element-dd7a4d1 elementor-widget elementor-widget-text-editor\" style=\"--align-content:initial;--align-items:initial;--align-self:initial;--flex-basis:initial;--flex-direction:initial;--flex-grow:initial;--flex-shrink:initial;--flex-wrap:initial;--gap:initial;--justify-content:initial;--order:initial;--swiper-navigation-size:44px;--swiper-pagination-bullet-horizontal-gap:6px;--swiper-pagination-bullet-size:6px;--swiper-theme-color:#000;--widgets-spacing:20px;-webkit-text-stroke-width:0px;align-content:var(--align-content);align-items:var(--align-items);align-self:var(--align-self);box-sizing:border-box;color:rgb(51, 51, 51);column-gap:50px;columns:1;flex-basis:var(--flex-basis);flex-direction:var(--flex-direction);flex-grow:var(--flex-grow);flex-shrink:var(--flex-shrink);flex-wrap:var(--flex-wrap);font-family:Lato, sans-serif;font-size:16px;font-style:normal;font-variant-caps:normal;font-variant-ligatures:normal;font-weight:400;justify-content:var(--justify-content);letter-spacing:normal;margin-bottom:0px;order:var(--order);orphans:2;position:relative;row-gap:;text-align:start;text-decoration-color:initial;text-decoration-style:initial;text-decoration-thickness:initial;text-indent:0px;text-transform:none;white-space:normal;widows:2;width:400px;word-spacing:0px;\" data-id=\"dd7a4d1\" data-element_type=\"widget\" data-widget_type=\"text-editor.default\"><div class=\"elementor-widget-container\" style=\"box-sizing:border-box;transition:background .3s,border .3s,border-radius .3s,box-shadow .3s,transform var(--e-transform-transition-duration,.4s);\"><p style=\"border-width:0px;box-sizing:border-box;font-size:16px;font-style:inherit;font-weight:inherit;margin:0px 0px 1.6em;outline:0px;padding:0px;vertical-align:baseline;\">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p><div class=\"elementor-element elementor-element-3b3dcbd elementor-widget elementor-widget-heading\" style=\"--align-content:initial;--align-items:initial;--align-self:initial;--flex-basis:initial;--flex-direction:initial;--flex-grow:initial;--flex-shrink:initial;--flex-wrap:initial;--gap:initial;--justify-content:initial;--order:initial;--swiper-navigation-size:44px;--swiper-pagination-bullet-horizontal-gap:6px;--swiper-pagination-bullet-size:6px;--swiper-theme-color:#000;--widgets-spacing:20px;-webkit-text-stroke-width:0px;align-content:var(--align-content);align-items:var(--align-items);align-self:var(--align-self);box-sizing:border-box;color:rgb(51, 51, 51);flex-basis:var(--flex-basis);flex-direction:var(--flex-direction);flex-grow:var(--flex-grow);flex-shrink:var(--flex-shrink);flex-wrap:var(--flex-wrap);font-family:Lato, sans-serif;font-size:16px;font-style:normal;font-variant-caps:normal;font-variant-ligatures:normal;font-weight:400;gap:var(--gap);justify-content:var(--justify-content);letter-spacing:normal;margin-bottom:0px;order:var(--order);orphans:2;position:relative;text-align:start;text-decoration-color:initial;text-decoration-style:initial;text-decoration-thickness:initial;text-indent:0px;text-transform:none;white-space:normal;widows:2;width:400px;word-spacing:0px;\" data-id=\"3b3dcbd\" data-element_type=\"widget\" data-widget_type=\"heading.default\"><div class=\"elementor-widget-container\" style=\"box-sizing:border-box;padding:0px;transition:background .3s,border .3s,border-radius .3s,box-shadow .3s,transform var(--e-transform-transition-duration,.4s);\"><h5 class=\"elementor-heading-title elementor-size-default\" style=\"border-width:0px;box-sizing:border-box;clear:both;color:var(--ast-global-color-2);font-family:Lato, sans-serif;font-size:1.125rem;font-style:inherit;line-height:1.2em;margin:0px;outline:0px;padding:0px;vertical-align:baseline;\"><strong>Quis nostrud</strong></h5></div></div><div class=\"elementor-element elementor-element-153375e elementor-widget elementor-widget-text-editor\" style=\"--align-content:initial;--align-items:initial;--align-self:initial;--flex-basis:initial;--flex-direction:initial;--flex-grow:initial;--flex-shrink:initial;--flex-wrap:initial;--gap:initial;--justify-content:initial;--order:initial;--swiper-navigation-size:44px;--swiper-pagination-bullet-horizontal-gap:6px;--swiper-pagination-bullet-size:6px;--swiper-theme-color:#000;--widgets-spacing:20px;-webkit-text-stroke-width:0px;align-content:var(--align-content);align-items:var(--align-items);align-self:var(--align-self);box-sizing:border-box;color:rgb(51, 51, 51);column-gap:50px;columns:1;flex-basis:var(--flex-basis);flex-direction:var(--flex-direction);flex-grow:var(--flex-grow);flex-shrink:var(--flex-shrink);flex-wrap:var(--flex-wrap);font-family:Lato, sans-serif;font-size:16px;font-style:normal;font-variant-caps:normal;font-variant-ligatures:normal;font-weight:400;justify-content:var(--justify-content);letter-spacing:normal;margin-bottom:0px;order:var(--order);orphans:2;position:relative;row-gap:;text-align:start;text-decoration-color:initial;text-decoration-style:initial;text-decoration-thickness:initial;text-indent:0px;text-transform:none;white-space:normal;widows:2;width:400px;word-spacing:0px;\" data-id=\"153375e\" data-element_type=\"widget\" data-widget_type=\"text-editor.default\"><div class=\"elementor-widget-container\" style=\"box-sizing:border-box;transition:background .3s,border .3s,border-radius .3s,box-shadow .3s,transform var(--e-transform-transition-duration,.4s);\"><p style=\"border-width:0px;box-sizing:border-box;font-size:16px;font-style:inherit;font-weight:inherit;margin:0px 0px 1.6em;outline:0px;padding:0px;vertical-align:baseline;\">Sed do eiusmod tempor incididunt ut labore.</p><div class=\"elementor-element elementor-element-6b6a2a8 elementor-widget elementor-widget-heading\" style=\"--align-content:initial;--align-items:initial;--align-self:initial;--flex-basis:initial;--flex-direction:initial;--flex-grow:initial;--flex-shrink:initial;--flex-wrap:initial;--gap:initial;--justify-content:initial;--order:initial;--swiper-navigation-size:44px;--swiper-pagination-bullet-horizontal-gap:6px;--swiper-pagination-bullet-size:6px;--swiper-theme-color:#000;--widgets-spacing:20px;-webkit-text-stroke-width:0px;align-content:var(--align-content);align-items:var(--align-items);align-self:var(--align-self);box-sizing:border-box;color:rgb(51, 51, 51);flex-basis:var(--flex-basis);flex-direction:var(--flex-direction);flex-grow:var(--flex-grow);flex-shrink:var(--flex-shrink);flex-wrap:var(--flex-wrap);font-family:Lato, sans-serif;font-size:16px;font-style:normal;font-variant-caps:normal;font-variant-ligatures:normal;font-weight:400;gap:var(--gap);justify-content:var(--justify-content);letter-spacing:normal;margin-bottom:0px;order:var(--order);orphans:2;position:relative;text-align:start;text-decoration-color:initial;text-decoration-style:initial;text-decoration-thickness:initial;text-indent:0px;text-transform:none;white-space:normal;widows:2;width:400px;word-spacing:0px;\" data-id=\"6b6a2a8\" data-element_type=\"widget\" data-widget_type=\"heading.default\"><div class=\"elementor-widget-container\" style=\"box-sizing:border-box;padding:0px;transition:background .3s,border .3s,border-radius .3s,box-shadow .3s,transform var(--e-transform-transition-duration,.4s);\"><h5 class=\"elementor-heading-title elementor-size-default\" style=\"border-width:0px;box-sizing:border-box;clear:both;color:var(--ast-global-color-2);font-family:Lato, sans-serif;font-size:1.125rem;font-style:inherit;line-height:1.2em;margin:0px;outline:0px;padding:0px;vertical-align:baseline;\"><strong>Duis aute irure</strong></h5></div></div><div class=\"elementor-element elementor-element-69e7302 elementor-widget elementor-widget-text-editor\" style=\"--align-content:initial;--align-items:initial;--align-self:initial;--flex-basis:initial;--flex-direction:initial;--flex-grow:initial;--flex-shrink:initial;--flex-wrap:initial;--gap:initial;--justify-content:initial;--order:initial;--swiper-navigation-size:44px;--swiper-pagination-bullet-horizontal-gap:6px;--swiper-pagination-bullet-size:6px;--swiper-theme-color:#000;--widgets-spacing:20px;-webkit-text-stroke-width:0px;align-content:var(--align-content);align-items:var(--align-items);align-self:var(--align-self);box-sizing:border-box;color:rgb(51, 51, 51);column-gap:50px;columns:1;flex-basis:var(--flex-basis);flex-direction:var(--flex-direction);flex-grow:var(--flex-grow);flex-shrink:var(--flex-shrink);flex-wrap:var(--flex-wrap);font-family:Lato, sans-serif;font-size:16px;font-style:normal;font-variant-caps:normal;font-variant-ligatures:normal;font-weight:400;justify-content:var(--justify-content);letter-spacing:normal;order:var(--order);orphans:2;position:relative;row-gap:;text-align:start;text-decoration-color:initial;text-decoration-style:initial;text-decoration-thickness:initial;text-indent:0px;text-transform:none;white-space:normal;widows:2;width:400px;word-spacing:0px;\" data-id=\"69e7302\" data-element_type=\"widget\" data-widget_type=\"text-editor.default\"><div class=\"elementor-widget-container\" style=\"box-sizing:border-box;transition:background .3s,border .3s,border-radius .3s,box-shadow .3s,transform var(--e-transform-transition-duration,.4s);\"><p style=\"border-width:0px;box-sizing:border-box;font-size:16px;font-style:inherit;font-weight:inherit;margin:0px 0px 1.6em;outline:0px;padding:0px;vertical-align:baseline;\">Dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore.</p></div></div></div></div></div></div><figure class=\"image image_resized image-style-align-right\" style=\"width:49.8%;\"><img style=\"aspect-ratio:600/600;\" src=\"\\ProductImages\\78195a7c-0c11-4c33-b632-aa41056058c2.jpg\" width=\"600\" height=\"600\" uploadprocessed=\"true\"></figure><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p>&nbsp;</p><p><strong>More about the product</strong></p><p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in.</p>", null, false, 150, "Anchor Bracelet", "Nam nec tellus a odio tincidunt auctor a ornare odio. Sed non mauris vitae erat consequat auctor eu in elit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Mauris in erat justo. Nullam ac urna eu felis dapibus condimentum sit amet a augue. Sed non neque elit sed.", null, null });

            migrationBuilder.InsertData(
                table: "ProductAttributeJoinTable",
                columns: new[] { "Id", "AttributeId", "ProductId" },
                values: new object[] { 1, 1, new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 2, new Guid("11111111-1111-1111-1111-111111111111") },
                    { 2, 3, new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "FileName", "FilePath", "IsFeatured", "IsFromEditor", "ProductId", "SortOrder" },
                values: new object[] { 1, "anchor-bracelet", "\\ProductImages\\description-3.jpg", true, false, new Guid("11111111-1111-1111-1111-111111111111"), 0 });

            migrationBuilder.InsertData(
                table: "ProductTermJoinTable",
                columns: new[] { "Id", "ProductId", "TermId" },
                values: new object[,]
                {
                    { 1, new Guid("11111111-1111-1111-1111-111111111111"), 1 },
                    { 2, new Guid("11111111-1111-1111-1111-111111111111"), 2 },
                    { 3, new Guid("11111111-1111-1111-1111-111111111111"), 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductAttributeJoinTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTermJoinTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTermJoinTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTermJoinTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));
        }
    }
}
