namespace asp.net_mvc_video_rental_store.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5181ad7f-0581-4ddc-82cd-fd0209ed65aa', N'admin@videorental.com', 0, N'AK8FIXs4mDRg03oTJzZYSp4otgbOsg/j66XGaqEg92f+l4oGQYChmOvf/ApqYnQkVQ==', N'859cdacf-f13f-42d8-ad27-9a98c6643d18', NULL, 0, 0, NULL, 1, 0, N'admin@videorental.com')");
            Sql(@"INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'62eb3c9e-221f-40fa-a96c-e36284fa57cb', N'guest@videorental.com', 0, N'AF8O1QuXMmygOYovyF6c4fMqISr4k5AU5oulnNeFAuFCFY/FxFvqUx7IwyA6muG+xg==', N'305e1f70-65c4-4939-a429-00af413c8915', NULL, 0, 0, NULL, 1, 0, N'guest@videorental.com')");
            Sql(@"INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0d1a6565-64de-4c86-b27d-770e4976d3c7', N'CanManageMovies')");
            Sql(@"INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5181ad7f-0581-4ddc-82cd-fd0209ed65aa', N'0d1a6565-64de-4c86-b27d-770e4976d3c7')");
        }
        
        public override void Down()
        {
        }
    }
}
