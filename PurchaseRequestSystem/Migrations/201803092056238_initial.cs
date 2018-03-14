namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VendorID = c.Int(nullable: false),
                        PartNumber = c.String(maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 150),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.String(nullable: false, maxLength: 150),
                        PhotoPath = c.String(maxLength: 255),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UpdatedByUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.VendorID, unique: true)
                .Index(t => t.PartNumber, unique: true);
            
            CreateTable(
                "dbo.PurchaseRequestLineItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchaseRequestID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UpdatedByUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.PurchaseRequestID, unique: true)
                .Index(t => t.ProductID, unique: true);
            
            CreateTable(
                "dbo.PurchaseRequests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        Justification = c.String(nullable: false, maxLength: 255),
                        DeliveryMode = c.String(nullable: false, maxLength: 25),
                        Status = c.String(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        ReasonForRejection = c.String(nullable: false, maxLength: 100),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 20),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UpdatedByUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 12),
                        Email = c.String(nullable: false, maxLength: 75),
                        IsReviewer = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        Name = c.String(maxLength: 255),
                        Address = c.String(maxLength: 255),
                        City = c.String(maxLength: 255),
                        OH = c.String(maxLength: 2),
                        Zip = c.String(maxLength: 5),
                        Phone = c.String(maxLength: 12),
                        Email = c.String(maxLength: 100),
                        IsPreApproved = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UpdatedByUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vendors", new[] { "Code" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "ProductID" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequestID" });
            DropIndex("dbo.Products", new[] { "PartNumber" });
            DropIndex("dbo.Products", new[] { "VendorID" });
            DropTable("dbo.Vendors");
            DropTable("dbo.Users");
            DropTable("dbo.Status");
            DropTable("dbo.PurchaseRequests");
            DropTable("dbo.PurchaseRequestLineItems");
            DropTable("dbo.Products");
        }
    }
}
