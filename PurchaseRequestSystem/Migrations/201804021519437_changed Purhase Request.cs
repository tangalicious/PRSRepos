namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedPurhaseRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseRequests", "Status", c => c.String());
            DropColumn("dbo.PurchaseRequests", "StatusID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseRequests", "StatusID", c => c.String());
            DropColumn("dbo.PurchaseRequests", "Status");
        }
    }
}
