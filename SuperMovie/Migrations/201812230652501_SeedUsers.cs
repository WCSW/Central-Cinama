namespace SuperMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'db944a72-9be0-433d-b25c-989fd2d19614', N'admin@supermovie.com', 0, N'AGTSp/h1dJ+QIZOvfwhqerFCNbFuqSNgzCcSVqxkhoRbKogbsSwa85ALblIbDu0t1w==', N'e55ca00b-25ec-4573-92be-e81e4f1013c2', NULL, 0, 0, NULL, 1, 0, N'admin@supermovie.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f7968c11-1a1d-44c9-94dc-0d09f0f9b1ea', N'guest@gmail.com', 0, N'ANpqQquok+L7ZYUQ7lwknsmTSmvWPYrlnSkk+aIYjTU5JgoMwlCM10tqBH+NIQlYOg==', N'6ea29d4d-27ae-4180-b319-2a1e14fb9616', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'73cc921c-f12d-4197-88c1-cd40e6e92fc4', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'db944a72-9be0-433d-b25c-989fd2d19614', N'73cc921c-f12d-4197-88c1-cd40e6e92fc4')

");
        }
        
        public override void Down()
        {
        }
    }
}
