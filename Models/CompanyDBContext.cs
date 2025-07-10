using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using EFDBFirstApproachNew.Models;
using EFDBFirstApproachNew.Migrations;
namespace EFDBFirstApproachNew.Models
{
    public class CompanyDBContext:DbContext
    {
        public CompanyDBContext() : base("MyConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDBContext, Configuration>());
        }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

    }
}