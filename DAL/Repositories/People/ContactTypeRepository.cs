using DAL.Interfaces;
using Domain.People;

namespace DAL.Repositories.People
{
    public class ContactTypeRepository : EFRepository<ContactType>, IContactTypeRepository
    {
        public ContactTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}