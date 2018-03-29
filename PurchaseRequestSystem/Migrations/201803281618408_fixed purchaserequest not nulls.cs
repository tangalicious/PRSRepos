namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedpurchaserequestnotnulls : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequests", "DeliveryMode", c => c.String(maxLength: 25));
            AlterColumn("dbo.PurchaseRequests", "ReasonForRejection", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "ReasonForRejection", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.PurchaseRequests", "DeliveryMode", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
