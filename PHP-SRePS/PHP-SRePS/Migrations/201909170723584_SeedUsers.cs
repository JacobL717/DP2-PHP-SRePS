namespace PHP_SRePS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1bfeb579-0e0f-4c49-8bac-5780f0ff5ea2', N'salesassistant@php.com.au', 0, N'ABMvsGVdbCV2ryfOI+MzPIa91O5k+Hg9/t/IRuWICUjnMmDteIth8chmwMLvwOm/jg==', N'c9c944d4-9209-45e2-a077-3ba10fff2ae3', NULL, 0, 0, NULL, 1, 0, N'salesassistant@php.com.au')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'84ca86d0-041c-4e5f-9db3-88a273aaf6bf', N'SalesAssistant')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1bfeb579-0e0f-4c49-8bac-5780f0ff5ea2', N'84ca86d0-041c-4e5f-9db3-88a273aaf6bf')");
        }
        
        public override void Down()
        {
        }
    }
}
