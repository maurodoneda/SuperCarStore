namespace SuperCarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCarsEntityRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Store_StoreId", "dbo.Stores");
            DropIndex("dbo.Cars", new[] { "Store_StoreId" });
            RenameColumn(table: "dbo.Cars", name: "Store_StoreId", newName: "StoreId");
            AlterColumn("dbo.Cars", "StoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "StoreId");
            AddForeignKey("dbo.Cars", "StoreId", "dbo.Stores", "StoreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "StoreId", "dbo.Stores");
            DropIndex("dbo.Cars", new[] { "StoreId" });
            AlterColumn("dbo.Cars", "StoreId", c => c.Int());
            RenameColumn(table: "dbo.Cars", name: "StoreId", newName: "Store_StoreId");
            CreateIndex("dbo.Cars", "Store_StoreId");
            AddForeignKey("dbo.Cars", "Store_StoreId", "dbo.Stores", "StoreId");
        }
    }
}
