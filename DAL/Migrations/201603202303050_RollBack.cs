namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RollBack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "EmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "PersonIdClient");
            DropColumn("dbo.Orders", "PersonIdEmployee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "PersonIdEmployee", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PersonIdClient", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "EmployeeId");
            DropColumn("dbo.Orders", "ClientId");
        }
    }
}
