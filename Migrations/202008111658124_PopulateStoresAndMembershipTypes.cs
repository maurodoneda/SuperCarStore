namespace SuperCarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStoresAndMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Address", c => c.String());
            AddColumn("dbo.Customers", "Address", c => c.String());
            DropColumn("dbo.Stores", "Adress");
            DropColumn("dbo.Customers", "Adress");


            Sql("INSERT INTO Stores (City,Country) VALUES ('London', 'UK');");
            Sql("INSERT INTO Stores (City,Country) VALUES ('Silverstone', 'UK');");
            Sql("INSERT INTO Stores (City,Country) VALUES ('Milan', 'Italy');");
            Sql("INSERT INTO Stores (City,Country) VALUES ('Las Vegas', 'USA');");
            Sql("INSERT INTO MembershipTypes (Type,Discount) VALUES ('None', 0);");
            Sql("INSERT INTO MembershipTypes (Type,Discount) VALUES ('Silver', 5);");
            Sql("INSERT INTO MembershipTypes (Type,Discount) VALUES ('Gold', 10);");
            Sql("INSERT INTO MembershipTypes (Type,Discount) VALUES ('Diamond', 20);");


        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Adress", c => c.String());
            AddColumn("dbo.Stores", "Adress", c => c.String());
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Stores", "Address");
        }
    }
}
