namespace GameLibra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthsToBasketsAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Developers", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Games", "Desription", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Genres", "Description", c => c.String(nullable: false, maxLength: 3000));
            AlterColumn("dbo.Libraries", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Libraries", "Desription", c => c.String(maxLength: 3000));
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Libraries", "Desription", c => c.String());
            AlterColumn("dbo.Libraries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "Desription", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Developers", "Name", c => c.String());
        }
    }
}
