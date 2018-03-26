namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUpdatedByUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PRLIs", "UpdatedByUser");
            DropColumn("dbo.Products", "UpdatedByUser");
            DropColumn("dbo.Vendors", "UpdatedByUser");
            DropColumn("dbo.PurchaseRequests", "UpdatedByUser");
            DropColumn("dbo.Users", "UpdatedByUser");
            DropColumn("dbo.Status", "UpdatedByUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Status", "UpdatedByUser", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UpdatedByUser", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseRequests", "UpdatedByUser", c => c.Int(nullable: false));
            AddColumn("dbo.Vendors", "UpdatedByUser", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "UpdatedByUser", c => c.Int(nullable: false));
            AddColumn("dbo.PRLIs", "UpdatedByUser", c => c.Int(nullable: false));
        }
    }
}
