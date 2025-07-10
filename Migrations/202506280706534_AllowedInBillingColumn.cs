namespace EFDBFirstApproachNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowedInBillingColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AllowedInBilling", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AllowedInBilling");
        }
    }
}
