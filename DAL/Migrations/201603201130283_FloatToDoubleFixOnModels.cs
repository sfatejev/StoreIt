namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FloatToDoubleFixOnModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderedProducts", "OrderedPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "ProductValue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductValue", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderedProducts", "OrderedPrice", c => c.Single(nullable: false));
        }
    }
}
