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


            #region Person seed
            context.ContactTypes.AddOrUpdate(
                new ContactType { ContactTypeActive = true, ContactTypeValue = "Mobiiltelefon" }, //ID1
                new ContactType { ContactTypeActive = true, ContactTypeValue = "E-mail" }, //ID2
                new ContactType { ContactTypeActive = true, ContactTypeValue = "Skype" } //ID3
                );

            context.PersonTypes.AddOrUpdate(
                new PersonType { PersonTypeActive = true, PersonTypeValue = "Töötaja" }, //ID1
                new PersonType { PersonTypeActive = true, PersonTypeValue = "Klient" }, //ID2
                new PersonType { PersonTypeActive = true, PersonTypeValue = "Partner" }, //ID3
                new PersonType { PersonTypeActive = true, PersonTypeValue = "Juhataja" } //ID4
                );

            context.People.AddOrUpdate(
                new Person { PersonActive = true, Firstname = "Peeter", Lastname = "Pakiraam", PersonTypeId = 1 }, //ID1
                new Person { PersonActive = true, Firstname = "Ants", Lastname = "Pakiraam", PersonTypeId = 1 }, //ID2
                new Person { PersonActive = true, Firstname = "Paula", Lastname = "Pakiraam", PersonTypeId = 2 }, //ID3
                new Person { PersonActive = true, Firstname = "Peeter", Lastname = "Lorenzo", PersonTypeId = 2 }, //ID4
                new Person { PersonActive = true, Firstname = "Al", Lastname = "Pacino", PersonTypeId = 3 }, //ID5
                new Person { PersonActive = true, Firstname = "Obama", Lastname = "Ohama", PersonTypeId = 4 }, //ID6 
                new Person { PersonActive = true, Firstname = "Scarabeus", Lastname = "Obama", PersonTypeId = 1 } //ID7
                );

            context.Contacts.AddOrUpdate(
                new Contact { ContactActive = true, ContactValue = "5553325", ContactTypeId = 1, PersonId = 1 },
                new Contact { ContactActive = true, ContactValue = "minapeeter", ContactTypeId = 3, PersonId = 1 },
                new Contact { ContactActive = true, ContactValue = "5552323", ContactTypeId = 1, PersonId = 2 },
                new Contact { ContactActive = true, ContactValue = "5552351", ContactTypeId = 1, PersonId = 3 },
                new Contact { ContactActive = true, ContactValue = "5544444", ContactTypeId = 1, PersonId = 4 },
                new Contact { ContactActive = true, ContactValue = "ppakiraam@itcollege.ee", ContactTypeId = 2, PersonId = 1 },
                new Contact { ContactActive = true, ContactValue = "5998989", ContactTypeId = 1, PersonId = 6 }
                );
            #endregion

            #region Users seed
            context.UserRoles.AddOrUpdate(
                new UserRole { UserRoleActive = true, UserRoleName = "Admin", UserRoleDescription = "Süsteemi administraator" },
                new UserRole { UserRoleActive = true, UserRoleName = "Employee", UserRoleDescription = "Töötajate tavakasutaja" },
                new UserRole { UserRoleActive = true, UserRoleName = "Client", UserRoleDescription = "Klientkasutaja" },
                new UserRole { UserRoleActive = true, UserRoleName = "root", UserRoleDescription = "Jumal" }
                );

            context.Users.AddOrUpdate(
                new User { UserActive = true, Username = "", Password = "", UserRoleId = 1, PersonId = 1 },
                new User { UserActive = true, Username = "", Password = "", UserRoleId = 2, PersonId = 2 },
                new User { UserActive = true, Username = "", Password = "", UserRoleId = 2, PersonId = 5 },
                new User { UserActive = true, Username = "", Password = "", UserRoleId = 2, PersonId = 7 }
                );
            #endregion

            #region Store seed 
            context.ProductCategories.AddOrUpdate(
                new ProductCategory { ProductCategoryActive = true, ProductCategoryValue = "Mootor", ProductCategoryDescription = "Sõidukite mootoriga seotud varuosad" },
                new ProductCategory { ProductCategoryActive = true, ProductCategoryValue = "Veermik", ProductCategoryDescription = "Sõidukite veermikuga seotud varuosad" }
                );

            context.Products.AddOrUpdate(
                new Product { ProductActive = true, ProductName = "Veepump", ProductValue = 120.5, ProductCategoryId = 1 },
                new Product { ProductActive = true, ProductName = "Hammasrihm", ProductValue = 50.75, ProductCategoryId = 1 },
                new Product { ProductActive = true, ProductName = "Sillaremondi komplekt", ProductValue = 320.50, ProductCategoryId = 2 },
                new Product { ProductActive = true, ProductName = "Koera saba", ProductValue = 1500.05, ProductCategoryId = 2 }
                );

            context.Storages.AddOrUpdate(
                new Storage { StorageName = "Tartu ladu" },
                new Storage { StorageName = "Tallinna ladu" }
                );

            context.StoredProducts.AddOrUpdate(
                new StoredProduct { StorageId = 1, ProductId = 1, Quantity = 100 },
                new StoredProduct { StorageId = 1, ProductId = 2, Quantity = 55 },
                new StoredProduct { StorageId = 1, ProductId = 3, Quantity = 100 },
                new StoredProduct { StorageId = 1, ProductId = 4, Quantity = 200 }
                );
            #endregion

            #region Orders seed
            context.OrderTypes.AddOrUpdate(
                new OrderType { OrderTypeActive = true, OrderTypeValue = "Arve", OrderTypeDescription = "Arved" }
                );

            context.Orders.AddOrUpdate(
                new Order { OrderTypeId = 1, ClientId = 3, EmployeeId = 1, OrderPaymentDate = new DateTime(2016, 6, 20) },
                new Order { OrderTypeId = 1, ClientId = 4, EmployeeId = 2, OrderPaymentDate = new DateTime(2016, 7, 25) }
                );

            context.OrderedProducts.AddOrUpdate(
                new OrderedProduct { OrderId = 1, ProductId = 1, OrderedPrice = 130, OrderedQuantity = 2},
                new OrderedProduct { OrderId = 1, ProductId = 2, OrderedPrice = 75, OrderedQuantity = 2 },
                new OrderedProduct { OrderId = 1, ProductId = 3, OrderedPrice = 400, OrderedQuantity = 1 },
                new OrderedProduct { OrderId = 2, ProductId = 2, OrderedPrice = 65, OrderedQuantity = 3 },
                new OrderedProduct { OrderId = 2, ProductId = 4, OrderedPrice = 2000, OrderedQuantity = 1 }
                );
            #endregion
        }
    }
}
