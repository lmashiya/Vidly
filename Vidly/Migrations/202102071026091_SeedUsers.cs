namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'97098424-0e1e-4670-94ae-e2c20c81a1d6', N'guest@vidly.com', 0, N'AC2Ir5lxrZhgzY+8DYGJ053aGt0wrYmvUJMlge7l3xwAmGjk9fKW/zEhofqU+IO11A==', N'73cd318b-4b79-4cb6-9042-94f3f338a017', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd0b25a39-6e8b-47c3-8df0-99763d1e31eb', N'admin@vidly.com', 0, N'ANWXn05r4q/ZXayOuVGeBb0X+r6lBNGfER30tFsPkL8BjkV0U5yqomKN9m4LjCBaew==', N'bdfb96f4-b8b5-48c3-a95e-ae4701f5832d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bf3fdfec-04ee-4e0a-a104-c5692dda25a6', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd0b25a39-6e8b-47c3-8df0-99763d1e31eb', N'bf3fdfec-04ee-4e0a-a104-c5692dda25a6')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
