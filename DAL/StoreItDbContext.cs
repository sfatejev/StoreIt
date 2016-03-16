using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Migrations;
using Domain.Orders;
using Domain.People;
using Domain.Store;
using Domain.Users;

namespace DAL
{
    public class StoreItDbContext : DbContext, IDbContext
    {
        public StoreItDbContext() : base("StoreItDbConnectionString")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StoreItDbContext, MigrationsConfiguration>());
#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif
        }

        //Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderEdit> OrderEdits { get; set; }
        public DbSet<OrderEditType> OrderEditTypes { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }

        //People
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }

        //Store
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductEdit> ProductEdits { get; set; }
        public DbSet<ProductEditType> ProductEditTypes { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<StoredProduct> StoredProducts { get; set; }

        //Users
        public DbSet<User> Users { get; set; }
        public DbSet<UserEdit> UserEdits { get; set; }
        public DbSet<UserEditType> UserEditTypes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
