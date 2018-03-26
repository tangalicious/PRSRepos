namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedmodelissues : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "VendorID" });
            CreateIndex("dbo.Products", "VendorID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "VendorID" });
            CreateIndex("dbo.Products", "VendorID", unique: true);
        }
    }
}
