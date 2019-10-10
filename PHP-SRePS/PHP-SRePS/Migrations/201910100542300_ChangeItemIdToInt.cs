namespace PHP_SRePS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeItemIdToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items");
            DropIndex("dbo.SalesTransactions", new[] { "ItemId" });
            DropPrimaryKey("dbo.Items");
            AlterColumn("dbo.Items", "ItemId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SalesTransactions", "ItemId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Items", "ItemId");
            CreateIndex("dbo.SalesTransactions", "ItemId");
            AddForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items", "ItemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items");
            DropIndex("dbo.SalesTransactions", new[] { "ItemId" });
            DropPrimaryKey("dbo.Items");
            AlterColumn("dbo.SalesTransactions", "ItemId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Items", "ItemId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Items", "ItemId");
            CreateIndex("dbo.SalesTransactions", "ItemId");
            AddForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items", "ItemId", cascadeDelete: true);
        }
    }
}
