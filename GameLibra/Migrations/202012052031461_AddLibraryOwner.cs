namespace GameLibra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLibraryOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Libraries", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Libraries", "ApplicationUserId");
            AddForeignKey("dbo.Libraries", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libraries", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Libraries", new[] { "ApplicationUserId" });
            DropColumn("dbo.Libraries", "ApplicationUserId");
        }
    }
}
