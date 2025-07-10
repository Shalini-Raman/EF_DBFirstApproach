namespace EFDBFirstApproachNew.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDBFirstApproachNew.Models.CompanyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EFDBFirstApproachNew.Models.CompanyDBContext";
        }

        protected override void Seed(EFDBFirstApproachNew.Models.CompanyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Brands.AddOrUpdate(new Models.Brands() { BrandID = 1, BrandName = "ONIDA" },new Models.Brands() { BrandID=2,BrandName="HP"},new Models.Brands() { BrandID = 3, BrandName = "Haier" });
            context.Categories.AddOrUpdate(new Models.categories() { CategoryID = 1, CategoryName = "Electronics" }, new Models.categories() { CategoryID = 3, CategoryName = "Home Appliances" });
            context.Products.AddOrUpdate(new Models.Products() { ProductID=1,ProductName="Mouse",CategoryID=1, BrandID = 1, Price =800,active=true,AvailabilityStatus="InStock",DOP=DateTime.Now });

        }
    }
}
