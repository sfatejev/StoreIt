namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
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
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.ContactTypeId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        ContactTypeId = c.Int(nullable: false, identity: true),
                        ContactTypeActive = c.Boolean(nullable: false),
                        ContactTypeValue_MultiLangStringId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactTypeId)
                .ForeignKey("dbo.MultiLangStrings", t => t.ContactTypeValue_MultiLangStringId)
                .Index(t => t.ContactTypeValue_MultiLangStringId);
            
            CreateTable(
                "dbo.MultiLangStrings",
                c => new
                    {
                        MultiLangStringId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Owner = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MultiLangStringId);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        TranslationId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        MultiLangStringId = c.Int(nullable: false),
                        Culture = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.TranslationId)
                .ForeignKey("dbo.MultiLangStrings", t => t.MultiLangStringId)
                .Index(t => t.MultiLangStringId);
            
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
                .ForeignKey("dbo.PersonTypes", t => t.PersonTypeId)
                .Index(t => t.PersonTypeId);
            
            CreateTable(
                "dbo.OrderEdits",
                c => new
                    {
                        OrderEditId = c.Int(nullable: false, identity: true),
                        OrderEditTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OrderEditTypeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderEditId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.OrderEditTypes", t => t.OrderEditTypeId)
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
                        OrderPaymentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OrderTypeId = c.Int(nullable: false),
                        ClientId = c.Int(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.OrderTypes", t => t.OrderTypeId)
                .ForeignKey("dbo.People", t => t.ClientId)
                .ForeignKey("dbo.People", t => t.EmployeeId)
                .Index(t => t.OrderTypeId)
                .Index(t => t.ClientId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        OrderedProductId = c.Int(nullable: false, identity: true),
                        OrderedQuantity = c.Int(nullable: false),
                        OrderedPrice = c.Double(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderedProductId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductValue = c.Double(nullable: false),
                        ProductActive = c.Boolean(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        ProductName_MultiLangStringId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .ForeignKey("dbo.MultiLangStrings", t => t.ProductName_MultiLangStringId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.ProductName_MultiLangStringId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryId = c.Int(nullable: false, identity: true),
                        ProductCategoryActive = c.Boolean(nullable: false),
                        ProductCategoryDescription_MultiLangStringId = c.Int(),
                        ProductCategoryValue_MultiLangStringId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductCategoryId)
                .ForeignKey("dbo.MultiLangStrings", t => t.ProductCategoryDescription_MultiLangStringId)
                .ForeignKey("dbo.MultiLangStrings", t => t.ProductCategoryValue_MultiLangStringId)
                .Index(t => t.ProductCategoryDescription_MultiLangStringId)
                .Index(t => t.ProductCategoryValue_MultiLangStringId);
            
            CreateTable(
                "dbo.ProductEdits",
                c => new
                    {
                        ProductEditId = c.Int(nullable: false, identity: true),
                        ProductEditTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ProductEditorId = c.Int(nullable: false),
                        ProductEditTypeId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductEditId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Users", t => t.ProductEditorId)
                .ForeignKey("dbo.ProductEditTypes", t => t.ProductEditTypeId)
                .Index(t => t.ProductEditorId)
                .Index(t => t.ProductEditTypeId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(maxLength: 128),
                        LastName = c.String(maxLength: 128),
                        UserRole_UserId = c.Int(),
                        UserRole_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId)
                .ForeignKey("dbo.UserRoles", t => new { t.UserRole_UserId, t.UserRole_RoleId })
                .Index(t => t.PersonId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => new { t.UserRole_UserId, t.UserRole_RoleId });
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        UserRoleId = c.Int(nullable: false),
                        UserRoleActive = c.Boolean(nullable: false),
                        UserRoleDescription_MultiLangStringId = c.Int(),
                        UserRoleName_MultiLangStringId = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.MultiLangStrings", t => t.UserRoleDescription_MultiLangStringId)
                .ForeignKey("dbo.MultiLangStrings", t => t.UserRoleName_MultiLangStringId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.UserRoleDescription_MultiLangStringId)
                .Index(t => t.UserRoleName_MultiLangStringId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Storages", t => t.StorageId)
                .Index(t => t.StorageId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        StorageId = c.Int(nullable: false, identity: true),
                        StorageName_MultiLangStringId = c.Int(),
                    })
                .PrimaryKey(t => t.StorageId)
                .ForeignKey("dbo.MultiLangStrings", t => t.StorageName_MultiLangStringId)
                .Index(t => t.StorageName_MultiLangStringId);
            
            CreateTable(
                "dbo.OrderTypes",
                c => new
                    {
                        OrderTypeId = c.Int(nullable: false, identity: true),
                        OrderTypeActive = c.Boolean(nullable: false),
                        OrderTypeDescription_MultiLangStringId = c.Int(),
                        OrderTypeValue_MultiLangStringId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderTypeId)
                .ForeignKey("dbo.MultiLangStrings", t => t.OrderTypeDescription_MultiLangStringId)
                .ForeignKey("dbo.MultiLangStrings", t => t.OrderTypeValue_MultiLangStringId)
                .Index(t => t.OrderTypeDescription_MultiLangStringId)
                .Index(t => t.OrderTypeValue_MultiLangStringId);
            
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
                        PersonTypeActive = c.Boolean(nullable: false),
                        PersonTypeDescription_MultiLangStringId = c.Int(),
                        PersonTypeValue_MultiLangStringId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonTypeId)
                .ForeignKey("dbo.MultiLangStrings", t => t.PersonTypeDescription_MultiLangStringId)
                .ForeignKey("dbo.MultiLangStrings", t => t.PersonTypeValue_MultiLangStringId)
                .Index(t => t.PersonTypeDescription_MultiLangStringId)
                .Index(t => t.PersonTypeValue_MultiLangStringId);
            
            CreateTable(
                "dbo.UserEdits",
                c => new
                    {
                        UserEditId = c.Int(nullable: false, identity: true),
                        UserEditTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserEditorId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserEditTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserEditId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserEditorId)
                .ForeignKey("dbo.UserEditTypes", t => t.UserEditTypeId)
                .Index(t => t.UserEditorId)
                .Index(t => t.UserId)
                .Index(t => t.UserEditTypeId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEdits", "UserEditTypeId", "dbo.UserEditTypes");
            DropForeignKey("dbo.UserEdits", "UserEditorId", "dbo.Users");
            DropForeignKey("dbo.UserEdits", "UserId", "dbo.Users");
            DropForeignKey("dbo.PersonTypes", "PersonTypeValue_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.PersonTypes", "PersonTypeDescription_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.People", "PersonTypeId", "dbo.PersonTypes");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.People");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.People");
            DropForeignKey("dbo.OrderEdits", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.OrderEdits", "OrderEditTypeId", "dbo.OrderEditTypes");
            DropForeignKey("dbo.OrderTypes", "OrderTypeValue_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.OrderTypes", "OrderTypeDescription_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.Orders", "OrderTypeId", "dbo.OrderTypes");
            DropForeignKey("dbo.StoredProducts", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.Storages", "StorageName_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.StoredProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductName_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.ProductEdits", "ProductEditTypeId", "dbo.ProductEditTypes");
            DropForeignKey("dbo.Users", new[] { "UserRole_UserId", "UserRole_RoleId" }, "dbo.UserRoles");
            DropForeignKey("dbo.UserRoles", "UserRoleName_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.UserRoles", "UserRoleDescription_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.ProductEdits", "ProductEditorId", "dbo.Users");
            DropForeignKey("dbo.Users", "PersonId", "dbo.People");
            DropForeignKey("dbo.OrderEdits", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductEdits", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductCategories", "ProductCategoryValue_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.ProductCategories", "ProductCategoryDescription_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.OrderedProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderEdits", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Contacts", "PersonId", "dbo.People");
            DropForeignKey("dbo.ContactTypes", "ContactTypeValue_MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.Translations", "MultiLangStringId", "dbo.MultiLangStrings");
            DropForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.UserEdits", new[] { "UserEditTypeId" });
            DropIndex("dbo.UserEdits", new[] { "UserId" });
            DropIndex("dbo.UserEdits", new[] { "UserEditorId" });
            DropIndex("dbo.PersonTypes", new[] { "PersonTypeValue_MultiLangStringId" });
            DropIndex("dbo.PersonTypes", new[] { "PersonTypeDescription_MultiLangStringId" });
            DropIndex("dbo.OrderTypes", new[] { "OrderTypeValue_MultiLangStringId" });
            DropIndex("dbo.OrderTypes", new[] { "OrderTypeDescription_MultiLangStringId" });
            DropIndex("dbo.Storages", new[] { "StorageName_MultiLangStringId" });
            DropIndex("dbo.StoredProducts", new[] { "ProductId" });
            DropIndex("dbo.StoredProducts", new[] { "StorageId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UserRoles", new[] { "UserRoleName_MultiLangStringId" });
            DropIndex("dbo.UserRoles", new[] { "UserRoleDescription_MultiLangStringId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "UserRole_UserId", "UserRole_RoleId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "PersonId" });
            DropIndex("dbo.ProductEdits", new[] { "ProductId" });
            DropIndex("dbo.ProductEdits", new[] { "ProductEditTypeId" });
            DropIndex("dbo.ProductEdits", new[] { "ProductEditorId" });
            DropIndex("dbo.ProductCategories", new[] { "ProductCategoryValue_MultiLangStringId" });
            DropIndex("dbo.ProductCategories", new[] { "ProductCategoryDescription_MultiLangStringId" });
            DropIndex("dbo.Products", new[] { "ProductName_MultiLangStringId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.OrderedProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderedProducts", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropIndex("dbo.Orders", new[] { "OrderTypeId" });
            DropIndex("dbo.OrderEdits", new[] { "Person_PersonId" });
            DropIndex("dbo.OrderEdits", new[] { "OrderId" });
            DropIndex("dbo.OrderEdits", new[] { "UserId" });
            DropIndex("dbo.OrderEdits", new[] { "OrderEditTypeId" });
            DropIndex("dbo.People", new[] { "PersonTypeId" });
            DropIndex("dbo.Translations", new[] { "MultiLangStringId" });
            DropIndex("dbo.ContactTypes", new[] { "ContactTypeValue_MultiLangStringId" });
            DropIndex("dbo.Contacts", new[] { "PersonId" });
            DropIndex("dbo.Contacts", new[] { "ContactTypeId" });
            DropTable("dbo.UserEditTypes");
            DropTable("dbo.UserEdits");
            DropTable("dbo.PersonTypes");
            DropTable("dbo.OrderEditTypes");
            DropTable("dbo.OrderTypes");
            DropTable("dbo.Storages");
            DropTable("dbo.StoredProducts");
            DropTable("dbo.ProductEditTypes");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.ProductEdits");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.OrderedProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderEdits");
            DropTable("dbo.People");
            DropTable("dbo.Translations");
            DropTable("dbo.MultiLangStrings");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
        }
    }
}
