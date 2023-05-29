namespace EFDBFirstApproachExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDBFirstApproachExample.Models.CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFDBFirstApproachExample.Models.CompanyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Brands.AddOrUpdate(new Models.Brand() { BrandID = 1, BrandName = "Sony" }, new Models.Brand() { BrandID = 2, BrandName = "nord" });
            context.Categories.AddOrUpdate(new Models.Category() { CategoryID = 1, CategoryName = "Machinery" }, new Models.Category() { CategoryID = 2, CategoryName = "Digital" });
            context.Products.AddOrUpdate(new Models.Product() { ProductId = 1, ProductName = "Sony", BrandId = 2, CategoryId = 2, Price = 50000, DateOfPurchase = DateTime.Now, AvailabilityStatus = "In-Stock" }, new Models.Product() { ProductId = 2, ProductName = "Mouse", BrandId = 2, CategoryId = 1, Price = 56000, DateOfPurchase = DateTime.Now, AvailabilityStatus = "Out-Stock" });
        }
    }
}
