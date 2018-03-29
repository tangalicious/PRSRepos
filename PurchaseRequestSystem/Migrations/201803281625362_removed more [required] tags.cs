namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedmorerequiredtags : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequests", "StatusID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "StatusID", c => c.String(nullable: false));
        }
    }
}
