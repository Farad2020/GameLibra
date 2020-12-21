namespace GameLibra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Release_date = c.DateTime(nullable: false),
                        Desription = c.String(),
                        DeveloperId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.DeveloperId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.DeveloperId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Games_and_Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games_and_Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Games_and_Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        LibraryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Libraries", t => t.LibraryId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.LibraryId);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desription = c.String(),
                        Creation_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games_and_Trailers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Games_and_Trailers", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games_and_Libraries", "LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Games_and_Libraries", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games_and_Images", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games_and_Genres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Games_and_Genres", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.Games_and_Trailers", new[] { "GameId" });
            DropIndex("dbo.Games_and_Libraries", new[] { "LibraryId" });
            DropIndex("dbo.Games_and_Libraries", new[] { "GameId" });
            DropIndex("dbo.Games_and_Images", new[] { "GameId" });
            DropIndex("dbo.Games_and_Genres", new[] { "GenreId" });
            DropIndex("dbo.Games_and_Genres", new[] { "GameId" });
            DropIndex("dbo.Games", new[] { "PublisherId" });
            DropIndex("dbo.Games", new[] { "DeveloperId" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Games_and_Trailers");
            DropTable("dbo.Libraries");
            DropTable("dbo.Games_and_Libraries");
            DropTable("dbo.Games_and_Images");
            DropTable("dbo.Genres");
            DropTable("dbo.Games_and_Genres");
            DropTable("dbo.Games");
            DropTable("dbo.Developers");
        }
    }
}
