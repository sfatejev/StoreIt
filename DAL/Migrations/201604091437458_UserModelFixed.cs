namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelFixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "UserRoleDescription_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.UserRoles", "UserRoleName_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.Users", new[] { "UserRole_UserId", "UserRole_RoleId" }, "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRole_UserId", "UserRole_RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserRoleDescription_MultiLangStringId" });
            DropIndex("dbo.UserRoles", new[] { "UserRoleName_MultiLangStringId" });
            DropColumn("dbo.Users", "UserRole_UserId");
            DropColumn("dbo.Users", "UserRole_RoleId");
            DropColumn("dbo.UserRoles", "UserRoleId");
            DropColumn("dbo.UserRoles", "UserRoleActive");
            DropColumn("dbo.UserRoles", "UserRoleDescription_MultiLangStringId");
            DropColumn("dbo.UserRoles", "UserRoleName_MultiLangStringId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRoles", "UserRoleName_MultiLangStringId", c => c.Int());
            AddColumn("dbo.UserRoles", "UserRoleDescription_MultiLangStringId", c => c.Int());
            AddColumn("dbo.UserRoles", "UserRoleActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserRoles", "UserRoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserRole_RoleId", c => c.Int());
            AddColumn("dbo.Users", "UserRole_UserId", c => c.Int());
            CreateIndex("dbo.UserRoles", "UserRoleName_MultiLangStringId");
            CreateIndex("dbo.UserRoles", "UserRoleDescription_MultiLangStringId");
            CreateIndex("dbo.Users", new[] { "UserRole_UserId", "UserRole_RoleId" });
            AddForeignKey("dbo.Users", new[] { "UserRole_UserId", "UserRole_RoleId" }, "dbo.UserRoles", new[] { "UserId", "RoleId" });
            AddForeignKey("dbo.UserRoles", "UserRoleName_MultiLangStringId", "dbo.MultiLangStrings", "MultiLangStringId");
            AddForeignKey("dbo.UserRoles", "UserRoleDescription_MultiLangStringId", "dbo.MultiLangStrings", "MultiLangStringId");
        }
    }
}
