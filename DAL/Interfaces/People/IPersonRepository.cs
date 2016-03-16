using System.Collections.Generic;
using Domain.Aggregate;
using Domain.People;

namespace DAL.Interfaces
{
    public interface IPersonRepository : IEFRepository<Person>
    {
        List<PersonWithContactCount> GetPeopleWithContactCounts();
    }
}