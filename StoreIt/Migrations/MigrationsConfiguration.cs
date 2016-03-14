using Domain.People;

namespace StoreIt.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class MigrationsConfiguration : DbMigrationsConfiguration<StoreIt.StoreItDbContext>
    {
        public MigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoreIt.StoreItDbContext context)
        {
            //TODO!! Complete creation of testdata seed
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
            context.ContactTypes.AddOrUpdate(p => p.ContactTypeId, 
                new ContactType {ContactTypeId = 0, ContactTypeValue = "Mobiiltelefon", ContactTypeActive = true, Contacts = null},
                new ContactType {ContactTypeId = 1, ContactTypeValue = "E-mail", ContactTypeActive = true, Contacts = null},
                new ContactType {ContactTypeId = 2, ContactTypeValue = "Skype", ContactTypeActive = true, Contacts = null});

            context.PersonTypes.AddOrUpdate(p => p.PersonTypeId,
                new PersonType {PersonTypeId = 0, PersonTypeValue = "Töötaja", PersonTypeActive = true, PersonTypeDescription = "Ettevõtte töötajad", Persons = null},
                new PersonType {PersonTypeId = 1,PersonTypeValue = "Juhtkond",PersonTypeActive = true,PersonTypeDescription = "Ettevõtte juhtiv personal",Persons = null},
                new PersonType {PersonTypeId = 2, PersonTypeValue = "Klient", PersonTypeActive = true, PersonTypeDescription = "Ettevõtte kliendid", Persons = null});
            */
            //TODO JÄTKATA!!!
        }
    }
}
