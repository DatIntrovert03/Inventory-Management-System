namespace Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.items",
                c => new
                    {
                        itemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Details = c.String(maxLength: 300),
                        Price = c.Double(nullable: false),
                        MeasuringUnit = c.String(),
                        ReOrderLevel = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.itemId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.items");
        }
    }
}
