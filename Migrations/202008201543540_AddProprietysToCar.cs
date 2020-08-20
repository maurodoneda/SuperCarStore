namespace SuperCarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProprietysToCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "NumberOfLikes", c => c.Int(nullable: true));
            AddColumn("dbo.Cars", "NumberOfDislikes", c => c.Int(nullable: true));
            AddColumn("dbo.Cars", "isRented", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "isRented");
            DropColumn("dbo.Cars", "NumberOfDislikes");
            DropColumn("dbo.Cars", "NumberOfLikes");
        }
    }
}
