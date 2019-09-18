namespace PHP_SRePS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'68258a01-bf1c-4db5-a925-7dcc3abadbcf', N'manager@php.com.au', 0, N'AEYQsUERvCDIfyvPrtPH2bmLBMDPpQ/Q/ip68YhVyl/Xe3pqt/lGI8edtraFFoV5Jw==', N'3123da44-6727-4da1-b10d-8c45649056cd', NULL, 0, 0, NULL, 1, 0, N'manager@php.com.au')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'beed0ed4-23ac-46d0-95f6-e700d8acc799', N'salesassistant@php.com.au', 0, N'ACInbMqWPBVP+ODoMLPP428fElv/cN+XEawlW7KA0csRiuuCx8Z/jiVY3h9gTVrD5Q==', N'f071fa40-876e-4851-abe9-bcd29fee39d9', NULL, 0, 0, NULL, 1, 0, N'salesassistant@php.com.au')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'23a1ae22-1b55-4c4a-b283-336ce1c7ec4d', N'Manager')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9cda92b9-defd-435b-b6ec-cfb81c18c526', N'SalesAssistant')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'68258a01-bf1c-4db5-a925-7dcc3abadbcf', N'23a1ae22-1b55-4c4a-b283-336ce1c7ec4d')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'beed0ed4-23ac-46d0-95f6-e700d8acc799', N'9cda92b9-defd-435b-b6ec-cfb81c18c526')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
