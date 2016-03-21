namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BiDirectionalNavigationPropertyFixOnOrderEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Client_PersonId", "dbo.People");
            DropForeignKey("dbo.Orders", "Employee_PersonId", "dbo.People");
            DropIndex("dbo.Orders", new[] { "Client_PersonId" });
            DropIndex("dbo.Orders", new[] { "Employee_PersonId" });
            DropColumn("dbo.Orders", "ClientId");
            DropColumn("dbo.Orders", "EmployeeId");
            RenameColumn(table: "dbo.Orders", name: "Client_PersonId", newName: "ClientId");
            RenameColumn(table: "dbo.Orders", name: "Employee_PersonId", newName: "EmployeeId");
            AlterColumn("dbo.Orders", "ClientId", c => c.Int(nullable: true));
            AlterColumn("dbo.Orders", "EmployeeId", c => c.Int(nullable: true));
            CreateIndex("dbo.Orders", "ClientId");
            CreateIndex("dbo.Orders", "EmployeeId");
            AddForeignKey("dbo.Orders", "ClientId", "dbo.People", "PersonId", cascadeDelete: false);
            AddForeignKey("dbo.Orders", "EmployeeId", "dbo.People", "PersonId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.People");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.People");
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            AlterColumn("dbo.Orders", "EmployeeId", c => c.Int());
            AlterColumn("dbo.Orders", "ClientId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "EmployeeId", newName: "Employee_PersonId");
            RenameColumn(table: "dbo.Orders", name: "ClientId", newName: "Client_PersonId");
            AddColumn("dbo.Orders", "EmployeeId", c => c.Int(nullable: true));
            AddColumn("dbo.Orders", "ClientId", c => c.Int(nullable: true));
            CreateIndex("dbo.Orders", "Employee_PersonId");
            CreateIndex("dbo.Orders", "Client_PersonId");
            AddForeignKey("dbo.Orders", "Employee_PersonId", "dbo.People", "PersonId");
            AddForeignKey("dbo.Orders", "Client_PersonId", "dbo.People", "PersonId");
        }
    }
}
