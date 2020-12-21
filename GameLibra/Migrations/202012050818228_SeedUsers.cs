namespace GameLibra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2a11c302-52fa-4c59-ad68-117d49251dae', N'guest@mail.ru', 0, N'AKOilbwDdgOMbL8AqwO0unXNAvds69LfiIJmu0U7pv7dJOUmRqe1crXIMEfnRec3zw==', N'dfcaf2b4-012c-4d25-baed-d21565dc6b06', NULL, 0, 0, NULL, 1, 0, N'guest@mail.ru')
                    INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'9d21b0e9-35d2-4db7-b284-aa087119b8a5', N'admin@mail.ru', 0, N'AJRIyOndxjuA2VaoKBXl/RBu20fzTapCixuLVq4Wkusj8ieLEsGf5sYpdgxY88wL1g==', N'82b38cca-b777-4129-8f53-70cc67b13d5e', NULL, 0, 0, NULL, 1, 0, N'admin@mail.ru')
                
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7928e4a0-940a-463e-844f-6e24b80dac33', N'CanManageEverything')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d21b0e9-35d2-4db7-b284-aa087119b8a5', N'7928e4a0-940a-463e-844f-6e24b80dac33')

"
                );
        }
        
        public override void Down()
        {
        }
    }
}
