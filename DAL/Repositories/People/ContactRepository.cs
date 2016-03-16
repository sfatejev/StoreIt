using DAL.Interfaces;
using Domain.People;

namespace DAL.Repositories.People
{
    public class ContactRepository : EFRepository<Contact>, IContactRepository
    {
        public ContactRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}