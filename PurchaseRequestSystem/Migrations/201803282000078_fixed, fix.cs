namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseRequestPRLIs", "PurchaseRequest_ID", "dbo.PurchaseRequests");
            DropForeignKey("dbo.PurchaseRequestPRLIs", "PRLIs_ID", "dbo.PRLIs");
            DropIndex("dbo.PurchaseRequestPRLIs", new[] { "PurchaseRequest_ID" });
            DropIndex("dbo.PurchaseRequestPRLIs", new[] { "PRLIs_ID" });
            CreateIndex("dbo.PRLIs", "PurchaseRequestID");
            AddForeignKey("dbo.PRLIs", "PurchaseRequestID", "dbo.PurchaseRequests", "ID", cascadeDelete: true);
            DropTable("dbo.PurchaseRequestPRLIs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PurchaseRequestPRLIs",
                c => new
                    {
                        PurchaseRequest_ID = c.Int(nullable: false),
                        PRLIs_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PurchaseRequest_ID, t.PRLIs_ID });
            
            DropForeignKey("dbo.PRLIs", "PurchaseRequestID", "dbo.PurchaseRequests");
            DropIndex("dbo.PRLIs", new[] { "PurchaseRequestID" });
            CreateIndex("dbo.PurchaseRequestPRLIs", "PRLIs_ID");
            CreateIndex("dbo.PurchaseRequestPRLIs", "PurchaseRequest_ID");
            AddForeignKey("dbo.PurchaseRequestPRLIs", "PRLIs_ID", "dbo.PRLIs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseRequestPRLIs", "PurchaseRequest_ID", "dbo.PurchaseRequests", "ID", cascadeDelete: true);
        }
    }
}
