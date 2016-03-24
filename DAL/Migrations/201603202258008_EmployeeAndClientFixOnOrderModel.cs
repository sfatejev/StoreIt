namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeAndClientFixOnOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PersonIdClient", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PersonIdEmployee", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "ClientId");
            DropColumn("dbo.Orders", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ClientId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "PersonIdEmployee");
            DropColumn("dbo.Orders", "PersonIdClient");
        }
    }
}
