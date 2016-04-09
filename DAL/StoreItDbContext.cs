using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotations;
using DAL.EFConfiguration;
using DAL.Helpers;
using DAL.Interfaces;
using DAL.Migrations;
using Domain;
using Domain.Orders;
using Domain.People;
using Domain.Store;
using Domain.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using NLog;

namespace DAL
{
    public class StoreItDbContext : DbContext, IDbContext
    {
        private readonly NLog.ILogger _logger;
        private readonly string _instanceId = Guid.NewGuid().ToString();

        [Inject]
        public StoreItDbContext(ILogger logger) : base("StoreItDbConnectionString")
        {
            _logger = logger;
            _logger.Debug("Instance id: " + _instanceId);
            Database.SetInitializer(new DbInitializer());

#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif
            Database.Log =
                s =>
                    _logger.Info((s.Contains("SELECT") || s.Contains("UPDATE") || s.Contains("DELETE") ||
                                  s.Contains("INSERT"))
                        ? "\n" + s.Trim()
                        : s.Trim());
        }

        public StoreItDbContext() : this(NLog.LogManager.GetCurrentClassLogger())
        {
        }

        public IDbSet<MultiLangString> MultiLangStrings { get; set; } 
        public IDbSet<Translation> Translations { get; set; } 

        //Orders
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderEdit> OrderEdits { get; set; }
        public IDbSet<OrderEditType> OrderEditTypes { get; set; }
        public IDbSet<OrderedProduct> OrderedProducts { get; set; }
        public IDbSet<OrderType> OrderTypes { get; set; }

        //People
        public IDbSet<Contact> Contacts { get; set; }
        public IDbSet<ContactType> ContactTypes { get; set; }
        public IDbSet<Person> People { get; set; }
        public IDbSet<PersonType> PersonTypes { get; set; }

        //Store
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductCategory> ProductCategories { get; set; }
        public IDbSet<ProductEdit> ProductEdits { get; set; }
        public IDbSet<ProductEditType> ProductEditTypes { get; set; }
        public IDbSet<Storage> Storages { get; set; }
        public IDbSet<StoredProduct> StoredProducts { get; set; }

        //Users
        /*
        public DbSet<User> Users { get; set; }
        public DbSet<UserEdit> UserEdits { get; set; }
        public DbSet<UserEditType> UserEditTypes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; } */

        public IDbSet<Role> Roles { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserClaim> UserClaims { get; set; }
        public IDbSet<UserLogin> UserLogins { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }

        public IDbSet<UserEdit> UserEdits { get; set; }
        public IDbSet<UserEditType> UserEditTypes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // remove tablename pluralizing
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // remove cascade delete
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Identity, PK - int 
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserClaimMap());
            modelBuilder.Configurations.Add(new UserLoginMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserRoleMap());

            Precision.ConfigureModelBuilder(modelBuilder);

            // convert all datetime and datetime? properties to datetime2 in ms sql
            // ms sql datetime has min value of 1753-01-01 00:00:00.000
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            // use Date type in ms sql, where [DataType(DataType.Date)] attribute is used
            modelBuilder.Properties<DateTime>()
           .Where(x => x.GetCustomAttributes(false).OfType<DataTypeAttribute>()
           .Any(a => a.DataType == DataType.Date))
           .Configure(c => c.HasColumnType("date"));

        }

        public override int SaveChanges()
        {
            // or watch this inside exception ((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _logger.Info("Disposing: " + disposing + " _instanceId: " + _instanceId);
            base.Dispose(disposing);
        }
    }
}


