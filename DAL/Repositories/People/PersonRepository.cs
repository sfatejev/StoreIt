using DAL.Interfaces;
using Domain.People;

namespace DAL.Repositories.People
{
    public class PersonRepository : EFRepository<Person>, IPersonRepository
    {
        public PersonRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}