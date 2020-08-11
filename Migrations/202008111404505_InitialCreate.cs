namespace SuperCarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.DateTime(nullable: false),
                        HP = c.Double(nullable: false),
                        EngineSpec = c.String(),
                        FuelType = c.String(),
                        TopSpeed = c.Double(nullable: false),
                        ZeroTo60 = c.Double(nullable: false),
                        SalePrice = c.Double(nullable: false),
                        RentalPrice = c.Double(nullable: false),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Adress = c.String(),
                        PostCode = c.String(),
                        Country = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Manager = c.String(),
                        CarId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DoB = c.DateTime(nullable: false),
                        Adress = c.String(),
                        PostCode = c.String(),
                        Country = c.String(),
                        IsSubscribed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Discount = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MembershipTypes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Stores", "CarId", "dbo.Cars");
            DropIndex("dbo.MembershipTypes", new[] { "CustomerId" });
            DropIndex("dbo.Stores", new[] { "CustomerId" });
            DropIndex("dbo.Stores", new[] { "CarId" });
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Stores");
            DropTable("dbo.Cars");
        }
    }
}
