namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Trashbalance = c.Double(nullable: false),
                        ZipId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        PickupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Pickups", t => t.PickupId, cascadeDelete: true)
                .ForeignKey("dbo.Zipcodes", t => t.ZipId, cascadeDelete: true)
                .Index(t => t.ZipId)
                .Index(t => t.UserId)
                .Index(t => t.PickupId);
            
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        PickupID = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.String(),
                        PickUpCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PickupID);
            
            CreateTable(
                "dbo.Zipcodes",
                c => new
                    {
                        ZipId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ZipId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ZipId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Zipcodes", t => t.ZipId, cascadeDelete: true)
                .Index(t => t.ZipId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ZipId", "dbo.Zipcodes");
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "ZipId", "dbo.Zipcodes");
            DropForeignKey("dbo.Customers", "PickupId", "dbo.Pickups");
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Employees", new[] { "ZipId" });
            DropIndex("dbo.Customers", new[] { "PickupId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "ZipId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Zipcodes");
            DropTable("dbo.Pickups");
            DropTable("dbo.Customers");
        }
    }
}
