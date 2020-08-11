namespace SuperCarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeToCustomers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MembershipTypes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.MembershipTypes", new[] { "CustomerId" });
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.MembershipTypes", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            CreateIndex("dbo.MembershipTypes", "CustomerId");
            AddForeignKey("dbo.MembershipTypes", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
