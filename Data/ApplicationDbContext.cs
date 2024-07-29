using ECommerce2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<AdditionalImage> ProductAdditionalImages { get; set; }
        public DbSet<AdditionalDetail> ProductAdditionalDetails { get; set; }
        public DbSet<Partnership> Partnerships { get; set; }
        public DbSet<SiteMedia> SiteMedias { get; set; }
        public DbSet<SpecialPromotion> SpecialPromotions { get; set; }
        public DbSet<Variant> Variations { get; set; }
        public DbSet<AttributeModel> Attributes { get; set; }
        public DbSet<Term> AttributeTerms { get; set; }
        public DbSet<ProductAttributeJoin> ProductAttributeJoinTable { get; set; }
        public DbSet<ProductTermJoin> ProductTermJoinTable { get; set; }
        public DbSet<TeamMember> Team { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .HasMany(p => p.ProductImages)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasMany(p => p.AdditionalImages)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Products)
                .UsingEntity<ProductCategories>();

            builder.Entity<AdditionalImage>()
                .HasOne(p => p.Image)
                .WithMany()
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Partnership>()
                .HasOne(p => p.Image)
                .WithMany()
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<SpecialPromotion>()
                .HasOne(sp => sp.SiteMedia)
                .WithMany()
                .HasForeignKey(sp => sp.SiteMediaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Term>()
                .HasOne(at => at.Attribute)
                .WithMany(at => at.Terms)
                .HasForeignKey(at => at.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasMany(p => p.Attributes)
                .WithMany(p => p.Products)
                .UsingEntity<ProductAttributeJoin>();

            builder.Entity<Product>()
                .HasMany(p => p.SelectedTerms)
                .WithMany()
                .UsingEntity<ProductTermJoin>();

            builder.Entity<Variant>()
                .HasMany(p => p.Terms)
                .WithMany()
                .UsingEntity<TermVariation>();

            builder.Entity<Variant>()
                .HasOne(v => v.Image)
                .WithMany()
                .HasForeignKey(p => p.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Variant>()
                .HasIndex(v => new { v.ProductId, v.TermsConcatenated })
                .IsUnique();

            builder.Entity<TeamMember>()
                .HasOne(tm => tm.Image)
                .WithMany()
                .HasForeignKey(tm => tm.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

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
                    new SpecialPromotion { Id = 1, Title = "20% Off On Tank Tops", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ac dictum.", Url = "#", ButtonText = "SHOP NOW", SiteMediaId = 1},
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
                    new Category { Id = 3, Name = "Accessories" }
                );
        }
    }
}
