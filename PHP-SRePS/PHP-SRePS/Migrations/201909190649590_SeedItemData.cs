namespace PHP_SRePS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedItemData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Items (ItemId, QuantityOnHand, Price, Name, ItemNotes ) VALUES ('000001', 15, 4.35, 'Panadol', 'Limit to 15 per customer.')");
            Sql("INSERT INTO Items (ItemId, QuantityOnHand, Price, Name, ItemNotes ) VALUES ('000002', 5, 12.99, 'Panadeine Forte', 'Limit to 1 per customer. Script required.')");
            Sql("INSERT INTO Items (ItemId, QuantityOnHand, Price, Name, ItemNotes ) VALUES ('000003', 20, 20.95, 'Maxalon', 'Limit to 1 per customer. Script required.')");
        }
        
        public override void Down()
        {
        }
    }
}
