using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using Domain.Aggregate;
using Domain.People;

namespace DAL.Repositories.People
{
    public class PersonRepository : EFRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<PersonWithContactCount> GetPeopleWithContactCounts()
        {
            return DbSet.Select(p => new PersonWithContactCount() {Person = p, ContactCount = p.Contacts.Count}).ToList();
        }
    }
}