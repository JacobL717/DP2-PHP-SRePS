namespace PHP_SRePS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeItemIdRequiredFieldForSalesTransaction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items");
            DropIndex("dbo.SalesTransactions", new[] { "ItemId" });
            AlterColumn("dbo.SalesTransactions", "ItemId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.SalesTransactions", "ItemId");
            AddForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items", "ItemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items");
            DropIndex("dbo.SalesTransactions", new[] { "ItemId" });
            AlterColumn("dbo.SalesTransactions", "ItemId", c => c.String(maxLength: 128));
            CreateIndex("dbo.SalesTransactions", "ItemId");
            AddForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items", "ItemId");
        }
    }
}
