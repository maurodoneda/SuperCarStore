namespace SuperCarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNullabeTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Year", c => c.DateTime());
            AlterColumn("dbo.Cars", "HP", c => c.Double());
            AlterColumn("dbo.Cars", "TopSpeed", c => c.Double());
            AlterColumn("dbo.Cars", "ZeroTo60", c => c.Double());
            AlterColumn("dbo.Cars", "SalePrice", c => c.Double());
            AlterColumn("dbo.Cars", "RentalPrice", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "RentalPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Cars", "SalePrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Cars", "ZeroTo60", c => c.Double(nullable: false));
            AlterColumn("dbo.Cars", "TopSpeed", c => c.Double(nullable: false));
            AlterColumn("dbo.Cars", "HP", c => c.Double(nullable: false));
            AlterColumn("dbo.Cars", "Year", c => c.DateTime(nullable: false));
        }
    }
}
