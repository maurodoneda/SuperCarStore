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
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Year = c.DateTime(nullable: false),
                        HP = c.Double(nullable: false),
                        EngineSpec = c.String(),
                        FuelType = c.String(),
                        TopSpeed = c.Double(nullable: false),
                        ZeroTo60 = c.Double(nullable: false),
                        SalePrice = c.Double(nullable: false),
                        RentalPrice = c.Double(nullable: false),
                        ImgUrl = c.String(),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
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
                    })
                .PrimaryKey(t => t.StoreId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        DoB = c.DateTime(nullable: false),
                        Adress = c.String(),
                        PostCode = c.String(),
                        Country = c.String(),
                        IsSubscribed = c.Boolean(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                        Store_StoreId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.Store_StoreId)
                .Index(t => t.MembershipTypeId)
                .Index(t => t.Store_StoreId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Store_StoreId", "dbo.Stores");
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.Cars", "StoreId", "dbo.Stores");
            DropIndex("dbo.Customers", new[] { "Store_StoreId" });
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropIndex("dbo.Cars", new[] { "StoreId" });
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Stores");
            DropTable("dbo.Cars");
        }
    }
}
