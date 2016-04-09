using Domain.Orders;
using Domain.People;
using Domain.Store;
using Domain.Users;

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class MigrationConfiguration : DbMigrationsConfiguration<DAL.StoreItDbContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.StoreItDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            /*
            #region Person seed
            context.ContactTypes.AddOrUpdate(
                new ContactType { ContactTypeId = 1, ContactTypeActive = true, ContactTypeValue = "Mobiiltelefon" },
                new ContactType { ContactTypeId = 2, ContactTypeActive = true, ContactTypeValue = "E-mail" },
                new ContactType { ContactTypeId = 3, ContactTypeActive = true, ContactTypeValue = "Skype" }
                );

            context.PersonTypes.AddOrUpdate(
                new PersonType { PersonTypeId = 1, PersonTypeActive = true, PersonTypeValue = "Töötaja" },
                new PersonType { PersonTypeId = 2, PersonTypeActive = true, PersonTypeValue = "Klient" },
                new PersonType { PersonTypeId = 3, PersonTypeActive = true, PersonTypeValue = "Partner" },
                new PersonType { PersonTypeId = 4, PersonTypeActive = true, PersonTypeValue = "Juhataja" }
                );

            context.People.AddOrUpdate(
                new Person { PersonId = 1, PersonActive = true, Firstname = "Peeter", Lastname = "Pakiraam", PersonTypeId = 1 }, //ID1
                new Person { PersonId = 2, PersonActive = true, Firstname = "Ants", Lastname = "Pakiraam", PersonTypeId = 1 }, //ID2
                new Person { PersonId = 3, PersonActive = true, Firstname = "Paula", Lastname = "Pakiraam", PersonTypeId = 2 }, //ID3
                new Person { PersonId = 4, PersonActive = true, Firstname = "Peeter", Lastname = "Lorenzo", PersonTypeId = 2 }, //ID4
                new Person { PersonId = 5, PersonActive = true, Firstname = "Al", Lastname = "Pacino", PersonTypeId = 3 }, //ID5
                new Person { PersonId = 6, PersonActive = true, Firstname = "Obama", Lastname = "Ohama", PersonTypeId = 4 }, //ID6 
                new Person { PersonId = 7, PersonActive = true, Firstname = "Scarabeus", Lastname = "Obama", PersonTypeId = 1 } //ID7
                );

            context.Contacts.AddOrUpdate(
                new Contact { ContactId = 1, ContactActive = true, ContactValue = "5553325", ContactTypeId = 1, PersonId = 1 },
                new Contact { ContactId = 2, ContactActive = true, ContactValue = "minapeeter", ContactTypeId = 3, PersonId = 1 },
                new Contact { ContactId = 3, ContactActive = true, ContactValue = "5552323", ContactTypeId = 1, PersonId = 2 },
                new Contact { ContactId = 4, ContactActive = true, ContactValue = "5552351", ContactTypeId = 1, PersonId = 3 },
                new Contact { ContactId = 5, ContactActive = true, ContactValue = "5544444", ContactTypeId = 1, PersonId = 4 },
                new Contact { ContactId = 6, ContactActive = true, ContactValue = "ppakiraam@itcollege.ee", ContactTypeId = 2, PersonId = 1 },
                new Contact { ContactId = 7, ContactActive = true, ContactValue = "5998989", ContactTypeId = 1, PersonId = 6 }
                );
            #endregion

            #region Users seed
            context.UserRoles.AddOrUpdate(
                new UserRole { UserRoleId = 1, UserRoleActive = true, UserRoleName = "Admin", UserRoleDescription = "Süsteemi administraator" },
                new UserRole { UserRoleId = 2, UserRoleActive = true, UserRoleName = "Employee", UserRoleDescription = "Töötajate tavakasutaja" },
                new UserRole { UserRoleId = 3, UserRoleActive = true, UserRoleName = "Client", UserRoleDescription = "Klientkasutaja" },
                new UserRole { UserRoleId = 4, UserRoleActive = true, UserRoleName = "root", UserRoleDescription = "Jumal" }
                );

            context.Users.AddOrUpdate(
                new User { UserId = 1, UserActive = true, Username = "", Password = "", UserRoleId = 1, PersonId = 1 },
                new User { UserId = 2, UserActive = true, Username = "", Password = "", UserRoleId = 2, PersonId = 2 },
                new User { UserId = 3, UserActive = true, Username = "", Password = "", UserRoleId = 2, PersonId = 5 },
                new User { UserId = 4, UserActive = true, Username = "", Password = "", UserRoleId = 2, PersonId = 7 }
                );
            #endregion

            #region Store seed 
            context.ProductCategories.AddOrUpdate(
                new ProductCategory { ProductCategoryId = 1, ProductCategoryActive = true, ProductCategoryValue = "Mootor", ProductCategoryDescription = "Sõidukite mootoriga seotud varuosad" },
                new ProductCategory { ProductCategoryId = 2, ProductCategoryActive = true, ProductCategoryValue = "Veermik", ProductCategoryDescription = "Sõidukite veermikuga seotud varuosad" }
                );

            context.Products.AddOrUpdate(
                new Product { ProductId = 1, ProductActive = true, ProductName = "Veepump", ProductValue = 120.5, ProductCategoryId = 1 },
                new Product { ProductId = 2, ProductActive = true, ProductName = "Hammasrihm", ProductValue = 50.75, ProductCategoryId = 1 },
                new Product { ProductId = 3, ProductActive = true, ProductName = "Sillaremondi komplekt", ProductValue = 320.50, ProductCategoryId = 2 },
                new Product { ProductId = 4, ProductActive = true, ProductName = "Koera saba", ProductValue = 1500.05, ProductCategoryId = 2 }
                );

            context.Storages.AddOrUpdate(
                new Storage { StorageId = 1, StorageName = "Tartu ladu" },
                new Storage { StorageId = 2, StorageName = "Tallinna ladu" }
                );

            context.StoredProducts.AddOrUpdate(
                new StoredProduct { StoredProductId = 1, StorageId = 1, ProductId = 1, Quantity = 100 },
                new StoredProduct { StoredProductId = 2, StorageId = 1, ProductId = 2, Quantity = 55 },
                new StoredProduct { StoredProductId = 3, StorageId = 1, ProductId = 3, Quantity = 100 },
                new StoredProduct { StoredProductId = 4, StorageId = 1, ProductId = 4, Quantity = 200 }
                );
            #endregion

            #region Orders seed
            context.OrderTypes.AddOrUpdate(
                new OrderType { OrderTypeId = 1, OrderTypeActive = true, OrderTypeValue = "Arve", OrderTypeDescription = "Arved" }
                );

            context.Orders.AddOrUpdate(
                new Order { OrderId = 1, OrderTypeId = 1, ClientId = 3, EmployeeId = 1, OrderPaymentDate = new DateTime(2016, 6, 20) },
                new Order { OrderId = 2, OrderTypeId = 1, ClientId = 4, EmployeeId = 2, OrderPaymentDate = new DateTime(2016, 7, 25) }
                );

            context.OrderedProducts.AddOrUpdate(
                new OrderedProduct { OrderedProductId = 1,OrderId = 1, ProductId = 1, OrderedPrice = 130.1, OrderedQuantity = 2 },
                new OrderedProduct { OrderedProductId = 2, OrderId = 1, ProductId = 2, OrderedPrice = 75, OrderedQuantity = 2 },
                new OrderedProduct { OrderedProductId = 3, OrderId = 1, ProductId = 3, OrderedPrice = 400, OrderedQuantity = 1 },
                new OrderedProduct { OrderedProductId = 4, OrderId = 2, ProductId = 2, OrderedPrice = 65, OrderedQuantity = 3 },
                new OrderedProduct { OrderedProductId = 5, OrderId = 2, ProductId = 4, OrderedPrice = 2000, OrderedQuantity = 1 }
                );
            #endregion */
        }
    }
}
