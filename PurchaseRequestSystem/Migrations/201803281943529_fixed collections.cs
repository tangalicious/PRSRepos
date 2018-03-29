namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedcollections : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PRLIs", "PurchaseRequestID", "dbo.PurchaseRequests");
            DropIndex("dbo.PRLIs", new[] { "PurchaseRequestID" });
            CreateTable(
                "dbo.PurchaseRequestPRLIs",
                c => new
                    {
                        PurchaseRequest_ID = c.Int(nullable: false),
                        PRLIs_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PurchaseRequest_ID, t.PRLIs_ID })
                .ForeignKey("dbo.PurchaseRequests", t => t.PurchaseRequest_ID, cascadeDelete: true)
                .ForeignKey("dbo.PRLIs", t => t.PRLIs_ID, cascadeDelete: true)
                .Index(t => t.PurchaseRequest_ID)
                .Index(t => t.PRLIs_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequestPRLIs", "PRLIs_ID", "dbo.PRLIs");
            DropForeignKey("dbo.PurchaseRequestPRLIs", "PurchaseRequest_ID", "dbo.PurchaseRequests");
            DropIndex("dbo.PurchaseRequestPRLIs", new[] { "PRLIs_ID" });
            DropIndex("dbo.PurchaseRequestPRLIs", new[] { "PurchaseRequest_ID" });
            DropTable("dbo.PurchaseRequestPRLIs");
            CreateIndex("dbo.PRLIs", "PurchaseRequestID");
            AddForeignKey("dbo.PRLIs", "PurchaseRequestID", "dbo.PurchaseRequests", "ID", cascadeDelete: true);
        }
    }
}
