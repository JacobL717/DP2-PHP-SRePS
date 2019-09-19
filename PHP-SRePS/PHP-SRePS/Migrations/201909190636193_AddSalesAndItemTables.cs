namespace PHP_SRePS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalesAndItemTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        QuantityOnHand = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Name = c.String(),
                        ItemNotes = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.SalesTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.String(maxLength: 128),
                        Quantitiy = c.Int(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesTransactions", "ItemId", "dbo.Items");
            DropIndex("dbo.SalesTransactions", new[] { "ItemId" });
            DropTable("dbo.SalesTransactions");
            DropTable("dbo.Items");
        }
    }
}
