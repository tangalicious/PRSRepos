namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class defaultsandfixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseRequests", "StatusID", c => c.String(nullable: false));
            DropColumn("dbo.PurchaseRequests", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseRequests", "Status", c => c.String(nullable: false));
            DropColumn("dbo.PurchaseRequests", "StatusID");
        }
    }
}
