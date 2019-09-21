namespace PHP_SRePS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedSpellingErrorInSalesTransactionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items");
            DropIndex("dbo.SalesTransactions", new[] { "ItemId" });
            AddColumn("dbo.SalesTransactions", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.SalesTransactions", "ItemId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.SalesTransactions", "ItemId");
            AddForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items", "ItemId", cascadeDelete: true);
            DropColumn("dbo.SalesTransactions", "Quantitiy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SalesTransactions", "Quantitiy", c => c.Int(nullable: false));
            DropForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items");
            DropIndex("dbo.SalesTransactions", new[] { "ItemId" });
            AlterColumn("dbo.SalesTransactions", "ItemId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Items", "Name", c => c.String());
            DropColumn("dbo.SalesTransactions", "Quantity");
            CreateIndex("dbo.SalesTransactions", "ItemId");
            AddForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items", "ItemId");
        }
    }
}
