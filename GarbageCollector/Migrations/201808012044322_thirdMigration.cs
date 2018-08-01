namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BonusPickup", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BonusPickup");
        }
    }
}
