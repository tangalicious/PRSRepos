namespace PurchaseRequestSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionalfixestomodelclassproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "State", c => c.String(maxLength: 2));
            DropColumn("dbo.Vendors", "OH");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendors", "OH", c => c.String(maxLength: 2));
            DropColumn("dbo.Vendors", "State");
        }
    }
}
