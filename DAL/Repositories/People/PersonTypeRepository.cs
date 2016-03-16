using DAL.Interfaces;
using Domain.People;

namespace DAL.Repositories.People
{
    public class PersonTypeRepository : EFRepository<PersonType>, IPersonTypeRepository
    {
        public PersonTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}