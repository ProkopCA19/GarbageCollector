namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zipcodes", "Areacode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zipcodes", "Areacode");
        }
    }
}
