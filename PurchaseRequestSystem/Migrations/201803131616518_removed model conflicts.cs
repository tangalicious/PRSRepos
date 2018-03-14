namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedmodelconflicts : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PRLIs", new[] { "PurchaseRequestID" });
            DropIndex("dbo.PRLIs", new[] { "ProductID" });
            CreateIndex("dbo.PRLIs", "PurchaseRequestID");
            CreateIndex("dbo.PRLIs", "ProductID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PRLIs", new[] { "ProductID" });
            DropIndex("dbo.PRLIs", new[] { "PurchaseRequestID" });
            CreateIndex("dbo.PRLIs", "ProductID", unique: true);
            CreateIndex("dbo.PRLIs", "PurchaseRequestID", unique: true);
        }
    }
}
