namespace GameLibra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiermentsToModelsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Game_Id", c => c.Int());
            AlterColumn("dbo.Developers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "Desription", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Libraries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Genres", "Game_Id");
            AddForeignKey("dbo.Genres", "Game_Id", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "Game_Id", "dbo.Games");
            DropIndex("dbo.Genres", new[] { "Game_Id" });
            AlterColumn("dbo.Publishers", "Name", c => c.String());
            AlterColumn("dbo.Libraries", "Name", c => c.String());
            AlterColumn("dbo.Genres", "Description", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Games", "Desription", c => c.String());
            AlterColumn("dbo.Games", "Name", c => c.String());
            AlterColumn("dbo.Developers", "Name", c => c.String());
            DropColumn("dbo.Genres", "Game_Id");
        }
    }
}
