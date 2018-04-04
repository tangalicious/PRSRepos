namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedcontroller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PRLIs", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PRLIs", "Subtotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PRLIs", "Subtotal");
            DropColumn("dbo.PRLIs", "Price");
        }
    }
}
