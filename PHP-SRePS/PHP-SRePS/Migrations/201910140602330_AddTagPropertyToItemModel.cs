namespace PHP_SRePS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTagPropertyToItemModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Tag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Tag");
        }
    }
}
