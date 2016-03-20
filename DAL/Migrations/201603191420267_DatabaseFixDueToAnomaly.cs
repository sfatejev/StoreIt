namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseFixDueToAnomaly : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactActive = c.Boolean(nullable: false),
                        ContactValue = c.String(maxLength: 64),
                        ContactTypeId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.ContactTypeId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        ContactTypeId = c.Int(nullable: false, identity: true),
                        ContactTypeValue = c.String(maxLength: 64),
                        ContactTypeActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactTypeId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        PersonActive = c.Boolean(nullable: false),
                        Firstname = c.String(maxLength: 32),
                        Lastname = c.String(maxLength: 32),
                        PersonTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.PersonTypes", t => t.PersonTypeId, cascadeDelete: true)
                .Index(t => t.PersonTypeId);
            
            CreateTable(
                "dbo.OrderEdits",
                c => new
                    {
                        OrderEditId = c.Int(nullable: false, identity: true),
                        OrderEditTime = c.DateTime(nullable: false),
                        OrderEditTypeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderEditId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.OrderEditTypes", t => t.OrderEditTypeId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.OrderEditTypeId)
                .Index(t => t.UserId)
                .Index(t => t.OrderId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderPaymentDate = c.DateTime(nullable: false),
                        OrderTypeId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Client_PersonId = c.Int(),
                        Employee_PersonId = c.Int(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.People", t => t.Client_PersonId)
                .ForeignKey("dbo.People", t => t.Employee_PersonId)
                .ForeignKey("dbo.OrderTypes", t => t.OrderTypeId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.OrderTypeId)
                .Index(t => t.Client_PersonId)
                .Index(t => t.Employee_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        OrderedProductId = c.Int(nullable: false, identity: true),
                        OrderedQuantity = c.Int(nullable: false),
                        OrderedPrice = c.Single(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderedProductId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 32),
                        ProductValue = c.Single(nullable: false),
                        ProductActive = c.Boolean(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryId = c.Int(nullable: false, identity: true),
                        ProductCategoryValue = c.String(maxLength: 64),
                        ProductCategoryDescription = c.String(),
                        ProductCategoryActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductEdits",
                c => new
                    {
                        ProductEditId = c.Int(nullable: false, identity: true),
                        ProductEditTime = c.DateTime(nullable: false),
                        ProductEditorId = c.Int(nullable: false),
                        ProductEditTypeId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductEditor_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductEditId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ProductEditor_UserId)
                .ForeignKey("dbo.ProductEditTypes", t => t.ProductEditTypeId, cascadeDelete: true)
                .Index(t => t.ProductEditTypeId)
                .Index(t => t.ProductId)
                .Index(t => t.ProductEditor_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        UserActive = c.Boolean(nullable: false),
                        UserRoleId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserRoleId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.UserEdits",
                c => new
                    {
                        UserEditId = c.Int(nullable: false, identity: true),
                        UserEditTime = c.DateTime(nullable: false),
                        UserEditorId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserEditTypeId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                        UserEditor_UserId = c.Int(),
                        User_UserId1 = c.Int(),
                        User_UserId2 = c.Int(),
                    })
                .PrimaryKey(t => t.UserEditId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Users", t => t.UserEditor_UserId)
                .ForeignKey("dbo.UserEditTypes", t => t.UserEditTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId1)
                .ForeignKey("dbo.Users", t => t.User_UserId2)
                .Index(t => t.UserEditTypeId)
                .Index(t => t.User_UserId)
                .Index(t => t.UserEditor_UserId)
                .Index(t => t.User_UserId1)
                .Index(t => t.User_UserId2);
            
            CreateTable(
                "dbo.UserEditTypes",
                c => new
                    {
                        UserEditTypeId = c.Int(nullable: false, identity: true),
                        UserEditTypeValue = c.String(maxLength: 32),
                        UserEditTypeDescription = c.String(),
                        UserEditTypeActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserEditTypeId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserRoleName = c.String(maxLength: 32),
                        UserRoleDescription = c.String(maxLength: 256),
                        UserRoleActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.ProductEditTypes",
                c => new
                    {
                        ProductEditTypeId = c.Int(nullable: false, identity: true),
                        ProductEditTypeValue = c.String(maxLength: 64),
                        ProductEditTypeActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductEditTypeId);
            
            CreateTable(
                "dbo.StoredProducts",
                c => new
                    {
                        StoredProductId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        StorageId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoredProductId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        StorageId = c.Int(nullable: false, identity: true),
                        StorageName = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.StorageId);
            
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        OrderTypeId = c.Int(nullable: false, identity: true),
                        OrderTypeValue = c.String(maxLength: 32),
                        OrderTypeDescription = c.String(maxLength: 256),
                        OrderTypeActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderTypeId);
            
            CreateTable(
                "dbo.OrderEditTypes",
                c => new
                    {
                        OrderEditTypeId = c.Int(nullable: false, identity: true),
                        OrderEditTypeValue = c.String(maxLength: 32),
                        OrderEditTypeDescription = c.String(),
                        OrderEditTypeActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderEditTypeId);
            
            CreateTable(
                "dbo.PersonTypes",
                c => new
                    {
                        PersonTypeId = c.Int(nullable: false, identity: true),
                        PersonTypeValue = c.String(maxLength: 64),
                        PersonTypeDescription = c.String(),
                        PersonTypeActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "PersonTypeId", "dbo.PersonTypes");
            DropForeignKey("dbo.Orders", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.OrderEdits", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.OrderEdits", "OrderEditTypeId", "dbo.OrderEditTypes");
            DropForeignKey("dbo.Orders", "OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.StoredProducts", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.StoredProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductEdits", "ProductEditTypeId", "dbo.ProductEditTypes");
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.ProductEdits", "ProductEditor_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "PersonId", "dbo.People");
            DropForeignKey("dbo.OrderEdits", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserEdits", "User_UserId2", "dbo.Users");
            DropForeignKey("dbo.UserEdits", "User_UserId1", "dbo.Users");
            DropForeignKey("dbo.UserEdits", "UserEditTypeId", "dbo.UserEditTypes");
            DropForeignKey("dbo.UserEdits", "UserEditor_UserId", "dbo.Users");
            DropForeignKey("dbo.UserEdits", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.ProductEdits", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.OrderedProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderEdits", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Employee_PersonId", "dbo.People");
            DropForeignKey("dbo.Orders", "Client_PersonId", "dbo.People");
            DropForeignKey("dbo.Contacts", "PersonId", "dbo.People");
            DropForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.StoredProducts", new[] { "ProductId" });
            DropIndex("dbo.StoredProducts", new[] { "StorageId" });
            DropIndex("dbo.UserEdits", new[] { "User_UserId2" });
            DropIndex("dbo.UserEdits", new[] { "User_UserId1" });
            DropIndex("dbo.UserEdits", new[] { "UserEditor_UserId" });
            DropIndex("dbo.UserEdits", new[] { "User_UserId" });
            DropIndex("dbo.UserEdits", new[] { "UserEditTypeId" });
            DropIndex("dbo.Users", new[] { "PersonId" });
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropIndex("dbo.ProductEdits", new[] { "ProductEditor_UserId" });
            DropIndex("dbo.ProductEdits", new[] { "ProductId" });
            DropIndex("dbo.ProductEdits", new[] { "ProductEditTypeId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.OrderedProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderedProducts", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "Person_PersonId" });
            DropIndex("dbo.Orders", new[] { "Employee_PersonId" });
            DropIndex("dbo.Orders", new[] { "Client_PersonId" });
            DropIndex("dbo.Orders", new[] { "OrderTypeId" });
            DropIndex("dbo.OrderEdits", new[] { "Person_PersonId" });
            DropIndex("dbo.OrderEdits", new[] { "OrderId" });
            DropIndex("dbo.OrderEdits", new[] { "UserId" });
            DropIndex("dbo.OrderEdits", new[] { "OrderEditTypeId" });
            DropIndex("dbo.People", new[] { "PersonTypeId" });
            DropIndex("dbo.Contacts", new[] { "PersonId" });
            DropIndex("dbo.Contacts", new[] { "ContactTypeId" });
            DropTable("dbo.PersonTypes");
            DropTable("dbo.OrderEditTypes");
            DropTable("dbo.OrderTypes");
            DropTable("dbo.Storages");
            DropTable("dbo.StoredProducts");
            DropTable("dbo.ProductEditTypes");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserEditTypes");
            DropTable("dbo.UserEdits");
            DropTable("dbo.Users");
            DropTable("dbo.ProductEdits");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.OrderedProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderEdits");
            DropTable("dbo.People");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
        }
    }
}
