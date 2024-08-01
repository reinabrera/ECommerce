using ECommerce2.Models;
using ECommerce2.Utility;
using Microsoft.Build.Experimental;
using Microsoft.EntityFrameworkCore;

namespace ECommerce2.Data
{
    public static class ModelBuilderExtensions
    {   
        public static void Seed(this ModelBuilder builder)
        {
            // Seeding Data

            builder.Entity<SiteMedia>()
                .HasData(
                    new SiteMedia { Id = 1, FileName = "special-promotion-1", FilePath = "\\Media\\special-promotion-1.jpg" },
                    new SiteMedia { Id = 2, FileName = "special-promotion-2", FilePath = "\\Media\\special-promotion-2.jpg" },
                    new SiteMedia { Id = 3, FileName = "special-promotion-3", FilePath = "\\Media\\special-promotion-3.jpg" },
                    new SiteMedia { Id = 4, FileName = "logo-1", FilePath = "\\Media\\logo-1.svg" },
                    new SiteMedia { Id = 5, FileName = "logo-2", FilePath = "\\Media\\logo-2.svg" },
                    new SiteMedia { Id = 6, FileName = "logo-3", FilePath = "\\Media\\logo-3.svg" },
                    new SiteMedia { Id = 7, FileName = "logo-4", FilePath = "\\Media\\logo-4.svg" },
                    new SiteMedia { Id = 8, FileName = "logo-5", FilePath = "\\Media\\logo-5.svg" },
                    new SiteMedia { Id = 9, FileName = "logo-6", FilePath = "\\Media\\logo-6.svg" },
                    new SiteMedia { Id = 10, FileName = "logo-7", FilePath = "\\Media\\logo-7.svg" },
                    new SiteMedia { Id = 11, FileName = "logo-8", FilePath = "\\Media\\logo-8.svg" },
                    new SiteMedia { Id = 12, FileName = "logo-9", FilePath = "\\Media\\logo-9.svg" },
                    new SiteMedia { Id = 13, FileName = "member-1", FilePath = "\\Media\\member-1.png" },
                    new SiteMedia { Id = 14, FileName = "member-2", FilePath = "\\Media\\member-2.png" },
                    new SiteMedia { Id = 15, FileName = "member-3", FilePath = "\\Media\\member-3.png" },
                    new SiteMedia { Id = 16, FileName = "member-4", FilePath = "\\Media\\member-4.png" },
                    new SiteMedia { Id = 17, FileName = "member-5", FilePath = "\\Media\\member-5.png" },
                    new SiteMedia { Id = 18, FileName = "member-6", FilePath = "\\Media\\member-6.png" },
                    new SiteMedia { Id = 19, FileName = "description-1", FilePath = "\\Media\\description-1.jpg" },
                    new SiteMedia { Id = 20, FileName = "description-2", FilePath = "\\Media\\description-2.jpg" },
                    new SiteMedia { Id = 21, FileName = "description-3", FilePath = "\\Media\\description-3.jpg" }
                );

            builder.Entity<SpecialPromotion>()
                .HasData(
                    new SpecialPromotion { Id = 1, Title = "20% Off On Tank Tops", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ac dictum.", Url = "#", ButtonText = "SHOP NOW", SiteMediaId = 1 },
                    new SpecialPromotion { Id = 2, Title = "Latest Eyewear For You", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ac dictum.", Url = "#", ButtonText = "SHOP NOW", SiteMediaId = 2 },
                    new SpecialPromotion { Id = 3, Title = "Let's Lorem Suit Up!", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ac dictum.", Url = "#", ButtonText = "SHOP NOW", SiteMediaId = 3 }
                );

            builder.Entity<Partnership>()
                .HasData(
                    new Partnership { Id = 1, CompanyName = "Lorem Ipsum", CompanyWebsite = "#", ImageId = 4 },
                    new Partnership { Id = 2, CompanyName = "Lorem Ipsum", CompanyWebsite = "#", ImageId = 5 },
                    new Partnership { Id = 3, CompanyName = "Lorem Ipsum", CompanyWebsite = "#", ImageId = 6 },
                    new Partnership { Id = 4, CompanyName = "Lorem Ipsum", CompanyWebsite = "#", ImageId = 7 },
                    new Partnership { Id = 5, CompanyName = "Lorem Ipsum", CompanyWebsite = "#", ImageId = 8 },
                    new Partnership { Id = 6, CompanyName = "Lorem Ipsum", CompanyWebsite = "#", ImageId = 9 },
                    new Partnership { Id = 7, CompanyName = "Lorem Ipsum", CompanyWebsite = "#", ImageId = 10 },
                    new Partnership { Id = 8, CompanyName = "Lorem Ipsum", CompanyWebsite = "#", ImageId = 11 },
                    new Partnership { Id = 9, CompanyName = "Lorem Ipsum", CompanyWebsite = "#", ImageId = 12 }
                );

            builder.Entity<TeamMember>()
                .HasData(
                    new TeamMember { Id = 1, Name = "Harvey Spector", Position = "Founder - CEO", ImageId = 13 },
                    new TeamMember { Id = 2, Name = "Jessica Pearsonn", Position = "COO", ImageId = 14 },
                    new TeamMember { Id = 3, Name = "Rachel Zain", Position = "Marketing Head", ImageId = 15 },
                    new TeamMember { Id = 4, Name = "Luise Litt", Position = "Lead Developer", ImageId = 16 },
                    new TeamMember { Id = 5, Name = "Katrina Bennett", Position = "Intern Designer", ImageId = 17 },
                    new TeamMember { Id = 6, Name = "Mike Ross", Position = "Intern Designer", ImageId = 18 }
                );

            builder.Entity<AttributeModel>()
                .HasData(
                    new AttributeModel { Id = 1, Name = "Color", Type = AttributeType.Color },
                    new AttributeModel { Id = 2, Name = "Size", Type = AttributeType.Button }
                );

            builder.Entity<Term>()
                .HasData(
                    new Term { Id = 1, AttributeId = 1, Name = "Black", ColorValue = "#000000" },
                    new Term { Id = 2, AttributeId = 1, Name = "Brown", ColorValue = "#aa7627" },
                    new Term { Id = 3, AttributeId = 1, Name = "Red", ColorValue = "#ce592f" },
                    new Term { Id = 4, AttributeId = 1, Name = "Aqua", ColorValue = "#1fb1c1" },
                    new Term { Id = 5, AttributeId = 1, Name = "Blue", ColorValue = "#1e73be" },
                    new Term { Id = 6, AttributeId = 1, Name = "Green", ColorValue = "#81d742" },
                    new Term { Id = 7, AttributeId = 1, Name = "Orange", ColorValue = "#f49922" },
                    new Term { Id = 8, AttributeId = 1, Name = "Purple", ColorValue = "#ce25e8" },
                    new Term { Id = 9, AttributeId = 1, Name = "Yellow", ColorValue = "#eac820" },
                    new Term { Id = 10, AttributeId = 1, Name = "White", ColorValue = "#ffffff" },
                    new Term { Id = 11, AttributeId = 2, Name = "S" },
                    new Term { Id = 12, AttributeId = 2, Name = "M" },
                    new Term { Id = 13, AttributeId = 2, Name = "L" }
                );

            builder.Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Men" },
                    new Category { Id = 2, Name = "Women" },
                    new Category { Id = 3, Name = "Accessories" },
                    new Category { Id = 4, Name = "Men's Shoes"},
                    new Category { Id = 5, Name = "Women's Jeans" },
                    new Category { Id = 6, Name = "Women's Shorts" },
                    new Category { Id = 7, Name = "Men's Shirts" },
                    new Category { Id = 8, Name = "Men's Jeans" },
                    new Category { Id = 9, Name = "Women's Shoes" },
                    new Category { Id = 10, Name = "Women's Shirts" }
                );

            Guid productId1 = Guid.Parse("11111111-1111-1111-1111-111111111111");
            Guid productId2 = Guid.Parse("11111111-1111-1111-1111-111111111112");
            Guid productId3 = Guid.Parse("11111111-1111-1111-1111-111111111113");
            Guid productId4 = Guid.Parse("11111111-1111-1111-1111-111111111114");
            Guid productId5 = Guid.Parse("11111111-1111-1111-1111-111111111115");
            Guid productId6 = Guid.Parse("11111111-1111-1111-1111-111111111116");
            Guid productId7 = Guid.Parse("11111111-1111-1111-1111-111111111117");
            Guid productId8 = Guid.Parse("11111111-1111-1111-1111-111111111118");
            Guid productId9 = Guid.Parse("11111111-1111-1111-1111-111111111119");
            Guid productId10 = Guid.Parse("11111111-1111-1111-1111-111111111120");
            Guid productId11 = Guid.Parse("11111111-1111-1111-1111-111111111121");
            Guid productId12 = Guid.Parse("11111111-1111-1111-1111-111111111122");
            Guid productId13 = Guid.Parse("11111111-1111-1111-1111-111111111123");
            Guid productId14 = Guid.Parse("11111111-1111-1111-1111-111111111124");
            Guid productId15 = Guid.Parse("11111111-1111-1111-1111-111111111125");
            Guid productId16 = Guid.Parse("11111111-1111-1111-1111-111111111126");
            Guid productId17 = Guid.Parse("11111111-1111-1111-1111-111111111127");
            Guid productId18 = Guid.Parse("11111111-1111-1111-1111-111111111128");
            Guid productId19 = Guid.Parse("11111111-1111-1111-1111-111111111129");
            Guid productId20 = Guid.Parse("11111111-1111-1111-1111-111111111130");
            Guid productId21 = Guid.Parse("11111111-1111-1111-1111-111111111131");
            Guid productId22 = Guid.Parse("11111111-1111-1111-1111-111111111132");

            builder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = productId1,
                        Name = "Anchor Bracelet",
                        IsFeatured = true,
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId2,
                        Name = "Basic Gray Jeans",
                        IsFeatured = true,
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId3,
                        Name = "Black Hoodie",
                        IsFeatured = true,
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId4,
                        Name = "Black Over-the-shoulder Handbag",
                        IsFeatured = true,
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId5,
                        Name = "Blue Denim Jeans",
                        IsFeatured = true,
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId6,
                        Name = "Blue Denim Shorts",
                        IsFeatured = true,
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = 130.00m,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 130.00m,
                        MaxPrice = 130.00m
                    },
                    new Product
                    {
                        Id = productId7,
                        Name = "Blue Hoodie",
                        IsFeatured = true,
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId8,
                        Name = "T-shirt for Men",
                        IsFeatured = true,
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 40.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 40.00m,
                        MaxPrice = 40.00m
                    },
                    new Product
                    {
                        Id = productId9,
                        Name = "Boho Bangle Bracelet",
                        IsFeatured = true,
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId10,
                        Name = "Bright Gold Purse With Chain",
                        IsFeatured = true,
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId11,
                        Name = "Bright Red Bag",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 100.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 100.00m,
                        MaxPrice = 100.00m
                    },
                    new Product
                    {
                        Id = productId12,
                        Name = "Buddha Bracelet",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId13,
                        Name = "Dark Blue Denim Jeans",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId14,
                        Name = "Dark Brown Jeans",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId15,
                        Name = "Dark Gray Jeans",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId16,
                        Name = "DNK Women Shoes",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 175.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 175.00m,
                        MaxPrice = 175.00m
                    },
                    new Product
                    {
                        Id = productId17,
                        Name = "Faint Washed Denim Blue Jeans",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId18,
                        Name = "Green Hoodie",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId19,
                        Name = "Light Brown Purse",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId20,
                        Name = "Red Hoodie",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId21,
                        Name = "Slim Fit Blue Jeans",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 150.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 150.00m,
                        MaxPrice = 150.00m
                    },
                    new Product
                    {
                        Id = productId22,
                        Name = "Flamingo Tshirt",
                        Overview = ProductData.Overview,
                        Description = ProductData.Description,
                        ListPrice = 25.00m,
                        SalePrice = null,
                        ShippingFee = null,
                        Inventory = 10,
                        IsPublished = true,
                        MinPrice = 25.00m,
                        MaxPrice = 25.00m
                    }
                );

            builder.Entity<ProductCategories>()
                .HasData(
                    new ProductCategories { Id = 1, ProductId = productId1, CategoryId = 2, Order = 2 },
                    new ProductCategories { Id = 2, ProductId = productId1, CategoryId = 3, Order = 1 },
                    new ProductCategories { Id = 3, ProductId = productId2, CategoryId = 2, Order = 1 },
                    new ProductCategories { Id = 4, ProductId = productId2, CategoryId = 5, Order = 2 },
                    new ProductCategories { Id = 5, ProductId = productId3, CategoryId = 1, Order = 1},
                    new ProductCategories { Id = 6, ProductId = productId4, CategoryId = 2, Order = 2 },
                    new ProductCategories { Id = 7, ProductId = productId4, CategoryId = 3, Order = 1 },
                    new ProductCategories { Id = 8, ProductId = productId5, CategoryId = 2, Order = 1 },
                    new ProductCategories { Id = 9, ProductId = productId5, CategoryId = 5, Order = 2 },
                    new ProductCategories { Id = 10, ProductId = productId6, CategoryId = 2, Order = 1 },
                    new ProductCategories { Id = 11, ProductId = productId6, CategoryId = 6, Order = 2 },
                    new ProductCategories { Id = 12, ProductId = productId7, CategoryId = 1, Order = 1 },
                    new ProductCategories { Id = 13, ProductId = productId8, CategoryId = 1, Order = 1 },
                    new ProductCategories { Id = 14, ProductId = productId8, CategoryId = 7, Order = 2 },
                    new ProductCategories { Id = 15, ProductId = productId9, CategoryId = 2, Order = 2 },
                    new ProductCategories { Id = 16, ProductId = productId9, CategoryId = 3, Order = 1 },
                    new ProductCategories { Id = 17, ProductId = productId10, CategoryId = 2, Order = 2 },
                    new ProductCategories { Id = 18, ProductId = productId10, CategoryId = 3, Order = 1 },
                    new ProductCategories { Id = 19, ProductId = productId11, CategoryId = 2, Order = 2 },
                    new ProductCategories { Id = 20, ProductId = productId11, CategoryId = 3, Order = 1 },
                    new ProductCategories { Id = 21, ProductId = productId12, CategoryId = 2, Order = 2 },
                    new ProductCategories { Id = 22, ProductId = productId12, CategoryId = 3, Order = 1 },
                    new ProductCategories { Id = 23, ProductId = productId13, CategoryId = 8, Order = 1 },
                    new ProductCategories { Id = 24, ProductId = productId13, CategoryId = 1, Order = 2 },
                    new ProductCategories { Id = 25, ProductId = productId14, CategoryId = 8, Order = 1 },
                    new ProductCategories { Id = 26, ProductId = productId14, CategoryId = 1, Order = 2 },
                    new ProductCategories { Id = 27, ProductId = productId15, CategoryId = 8, Order = 1 },
                    new ProductCategories { Id = 28, ProductId = productId15, CategoryId = 1, Order = 2 },
                    new ProductCategories { Id = 29, ProductId = productId16, CategoryId = 2, Order = 1 },
                    new ProductCategories { Id = 39, ProductId = productId16, CategoryId = 9, Order = 2 },
                    new ProductCategories { Id = 40, ProductId = productId17, CategoryId = 8, Order = 1 },
                    new ProductCategories { Id = 41, ProductId = productId17, CategoryId = 1, Order = 2 },
                    new ProductCategories { Id = 42, ProductId = productId18, CategoryId = 8, Order = 1 },
                    new ProductCategories { Id = 43, ProductId = productId19, CategoryId = 2, Order = 2 },
                    new ProductCategories { Id = 44, ProductId = productId19, CategoryId = 3, Order = 1 },
                    new ProductCategories { Id = 45, ProductId = productId20, CategoryId = 1, Order = 1 },
                    new ProductCategories { Id = 46, ProductId = productId21, CategoryId = 2, Order = 1 },
                    new ProductCategories { Id = 47, ProductId = productId21, CategoryId = 9, Order = 2 },
                    new ProductCategories { Id = 48, ProductId = productId22, CategoryId = 10, Order = 1 },
                    new ProductCategories { Id = 49, ProductId = productId22, CategoryId = 2, Order = 2 }
                );

            builder.Entity<ProductAttributeJoin>()
                .HasData(
                    new ProductAttributeJoin { Id = 1, ProductId = productId1, AttributeId = 1},
                    new ProductAttributeJoin { Id = 2, ProductId = productId8, AttributeId = 1 },
                    new ProductAttributeJoin { Id = 3, ProductId = productId9, AttributeId = 1 },
                    new ProductAttributeJoin { Id = 4, ProductId = productId11, AttributeId = 1 },
                    new ProductAttributeJoin { Id = 5, ProductId = productId16, AttributeId = 1 },
                    new ProductAttributeJoin { Id = 6, ProductId = productId22, AttributeId = 1 },
                    new ProductAttributeJoin { Id = 7, ProductId = productId22, AttributeId = 2 }
                );

            builder.Entity<ProductTermJoin>()
                .HasData(
                    new ProductTermJoin { Id = 1, ProductId = productId1, TermId = 1 },
                    new ProductTermJoin { Id = 2, ProductId = productId1, TermId = 2 },
                    new ProductTermJoin { Id = 3, ProductId = productId1, TermId = 3 },
                    new ProductTermJoin { Id = 4, ProductId = productId8, TermId = 3 },
                    new ProductTermJoin { Id = 5, ProductId = productId8, TermId = 4 },
                    new ProductTermJoin { Id = 6, ProductId = productId8, TermId = 5 },
                    new ProductTermJoin { Id = 7, ProductId = productId8, TermId = 6 },
                    new ProductTermJoin { Id = 8, ProductId = productId9, TermId = 3 },
                    new ProductTermJoin { Id = 9, ProductId = productId9, TermId = 4 },
                    new ProductTermJoin { Id = 10, ProductId = productId9, TermId = 6 },
                    new ProductTermJoin { Id = 11, ProductId = productId11, TermId = 5 },
                    new ProductTermJoin { Id = 12, ProductId = productId11, TermId = 7 },
                    new ProductTermJoin { Id = 13, ProductId = productId11, TermId = 8 },
                    new ProductTermJoin { Id = 14, ProductId = productId11, TermId = 3 },
                    new ProductTermJoin { Id = 15, ProductId = productId16, TermId = 3 },
                    new ProductTermJoin { Id = 16, ProductId = productId16, TermId = 4 },
                    new ProductTermJoin { Id = 17, ProductId = productId16, TermId = 5 },
                    new ProductTermJoin { Id = 18, ProductId = productId16, TermId = 6 },
                    new ProductTermJoin { Id = 19, ProductId = productId22, TermId = 5 },
                    new ProductTermJoin { Id = 20, ProductId = productId22, TermId = 7 },
                    new ProductTermJoin { Id = 21, ProductId = productId22, TermId = 8 },
                    new ProductTermJoin { Id = 22, ProductId = productId22, TermId = 9 },
                    new ProductTermJoin { Id = 23, ProductId = productId22, TermId = 11 },
                    new ProductTermJoin { Id = 24, ProductId = productId22, TermId = 12 },
                    new ProductTermJoin { Id = 25, ProductId = productId22, TermId = 13 }
                );

            builder.Entity<ProductImage>()
                .HasData(
                    new ProductImage { Id = 1, ProductId = productId1, FileName = "anchor-bracelet", FilePath = "\\ProductImages\\anchor-bracelet.jpg", IsFeatured = true },
                    new ProductImage { Id = 2, ProductId = productId2, FileName = "women-jean-1", FilePath = "\\ProductImages\\women-jean-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 3, ProductId = productId3, FileName = "hoodie-1", FilePath = "\\ProductImages\\hoodie-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 4, ProductId = productId4, FileName = "bag-1", FilePath = "\\ProductImages\\bag-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 5, ProductId = productId5, FileName = "women-jean-2", FilePath = "\\ProductImages\\women-jean-2.jpg", IsFeatured = true },
                    new ProductImage { Id = 6, ProductId = productId6, FileName = "women-short-1", FilePath = "\\ProductImages\\women-short-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 7, ProductId = productId7, FileName = "hoodie-2", FilePath = "\\ProductImages\\hoodie-2.jpg", IsFeatured = true },
                    new ProductImage { Id = 8, ProductId = productId8, FileName = "tshirt-aqua-1", FilePath = "\\ProductImages\\tshirt-aqua-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 9, ProductId = productId8, FileName = "tshirt-blue-1", FilePath = "\\ProductImages\\tshirt-blue-1.jpg" },
                    new ProductImage { Id = 10, ProductId = productId8, FileName = "tshirt-green-1", FilePath = "\\ProductImages\\tshirt-green-1.jpg" },
                    new ProductImage { Id = 11, ProductId = productId8, FileName = "tshirt-red-1", FilePath = "\\ProductImages\\tshirt-red-1.jpg" },
                    new ProductImage { Id = 12, ProductId = productId9, FileName = "bracelet-aqua-1", FilePath = "\\ProductImages\\bracelet-aqua-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 13, ProductId = productId9, FileName = "bracelet-green-1", FilePath = "\\ProductImages\\bracelet-green-1.jpg" },
                    new ProductImage { Id = 14, ProductId = productId9, FileName = "bracelet-red-1", FilePath = "\\ProductImages\\bracelet-red-1.jpg" },
                    new ProductImage { Id = 15, ProductId = productId10, FileName = "bag-2", FilePath = "\\ProductImages\\bag-2.jpg", IsFeatured = true },
                    new ProductImage { Id = 16, ProductId = productId11, FileName = "bag-blue-1", FilePath = "\\ProductImages\\bag-blue-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 17, ProductId = productId11, FileName = "bag-orange-1", FilePath = "\\ProductImages\\bag-orange-1.jpg" },
                    new ProductImage { Id = 18, ProductId = productId11, FileName = "bag-purple-1", FilePath = "\\ProductImages\\bag-purple-1.jpg" },
                    new ProductImage { Id = 19, ProductId = productId11, FileName = "bag-red-1", FilePath = "\\ProductImages\\bag-red-1.jpg" },
                    new ProductImage { Id = 20, ProductId = productId12, FileName = "bracelet-1", FilePath = "\\ProductImages\\bracelet-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 21, ProductId = productId13, FileName = "men-jean-1", FilePath = "\\ProductImages\\men-jean-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 22, ProductId = productId14, FileName = "men-jean-2", FilePath = "\\ProductImages\\men-jean-2.jpg", IsFeatured = true },
                    new ProductImage { Id = 23, ProductId = productId15, FileName = "men-jean-3", FilePath = "\\ProductImages\\men-jean-3.jpg", IsFeatured = true },
                    new ProductImage { Id = 24, ProductId = productId16, FileName = "women-shoes-aqua-1", FilePath = "\\ProductImages\\women-shoes-aqua-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 25, ProductId = productId16, FileName = "women-shoes-blue-1", FilePath = "\\ProductImages\\women-shoes-blue-1.jpg" },
                    new ProductImage { Id = 26, ProductId = productId16, FileName = "women-shoes-green-1", FilePath = "\\ProductImages\\women-shoes-green-1.jpg" },
                    new ProductImage { Id = 27, ProductId = productId16, FileName = "women-shoes-red-1", FilePath = "\\ProductImages\\women-shoes-red-1.jpg" },
                    new ProductImage { Id = 28, ProductId = productId17, FileName = "men-jean-4", FilePath = "\\ProductImages\\men-jean-4.jpg", IsFeatured = true },
                    new ProductImage { Id = 29, ProductId = productId18, FileName = "hoodie-3", FilePath = "\\ProductImages\\hoodie-3.jpg", IsFeatured = true },
                    new ProductImage { Id = 30, ProductId = productId19, FileName = "bag-3", FilePath = "\\ProductImages\\bag-3.jpg", IsFeatured = true },
                    new ProductImage { Id = 31, ProductId = productId20, FileName = "hoodie-4", FilePath = "\\ProductImages\\hoodie-4.jpg", IsFeatured = true },
                    new ProductImage { Id = 32, ProductId = productId21, FileName = "women-jean-3", FilePath = "\\ProductImages\\women-jean-3.jpg", IsFeatured = true },
                    new ProductImage { Id = 33, ProductId = productId22, FileName = "tshirt-flamingo-blue-1", FilePath = "\\ProductImages\\tshirt-flamingo-blue-1.jpg", IsFeatured = true },
                    new ProductImage { Id = 34, ProductId = productId22, FileName = "tshirt-flamingo-orange-1", FilePath = "\\ProductImages\\tshirt-flamingo-orange-1.jpg" },
                    new ProductImage { Id = 35, ProductId = productId22, FileName = "tshirt-flamingo-purple-1", FilePath = "\\ProductImages\\tshirt-flamingo-purple-1.jpg" },
                    new ProductImage { Id = 36, ProductId = productId22, FileName = "tshirt-flamingo-yellow-1", FilePath = "\\ProductImages\\tshirt-flamingo-yellow-1.jpg" }
                );
        }
    }
}
