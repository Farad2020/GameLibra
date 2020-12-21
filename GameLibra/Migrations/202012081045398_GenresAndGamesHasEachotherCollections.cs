namespace GameLibra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenresAndGamesHasEachotherCollections : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Game_Id", "dbo.Games");
            DropIndex("dbo.Genres", new[] { "Game_Id" });
            CreateTable(
                "dbo.GenreGames",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Game_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Game_Id);
            
            DropColumn("dbo.Genres", "Game_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Game_Id", c => c.Int());
            DropForeignKey("dbo.GenreGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.GenreGames", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.GenreGames", new[] { "Game_Id" });
            DropIndex("dbo.GenreGames", new[] { "Genre_Id" });
            DropTable("dbo.GenreGames");
            CreateIndex("dbo.Genres", "Game_Id");
            AddForeignKey("dbo.Genres", "Game_Id", "dbo.Games", "Id");
        }
    }
}
