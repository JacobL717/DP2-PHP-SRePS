namespace PHP_SRePS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedSalesTransactions : DbMigration
    {
        public override void Up()
        {
            Sql(
            @"
            SET IDENTITY_INSERT[dbo].[SalesTransactions] ON
            INSERT INTO[dbo].[SalesTransactions] ([Id], [ItemId], [TotalPrice], [Date], [Notes], [Quantity]) VALUES(0, N'000002', 25.98, N'2019-09-21 12:53:19', NULL, 2)
            INSERT INTO[dbo].[SalesTransactions] ([Id], [ItemId], [TotalPrice], [Date], [Notes], [Quantity]) VALUES(1, N'000003', 20.95, N'2019-09-23 17:12:30', N'This is a dummy transaction.', 1)
            INSERT INTO[dbo].[SalesTransactions] ([Id], [ItemId], [TotalPrice], [Date], [Notes], [Quantity]) VALUES(2, N'000001', 43.5, N'2019-09-23 17:12:44', NULL, 10)
            SET IDENTITY_INSERT[dbo].[SalesTransactions] OFF
            ");
        }

    public override void Down()
        {
        }
    }
}
