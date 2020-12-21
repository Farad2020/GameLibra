namespace GameLibra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customValidationOnDevsAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Developers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Developers", "Name", c => c.String(nullable: false));
        }
    }
}
