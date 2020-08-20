namespace SuperCarStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProprietysToCar1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "NumberOfLikes", c => c.Int());
            AlterColumn("dbo.Cars", "NumberOfDislikes", c => c.Int());
            AlterColumn("dbo.Cars", "isRented", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "isRented", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Cars", "NumberOfDislikes", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "NumberOfLikes", c => c.Int(nullable: false));
        }
    }
}
