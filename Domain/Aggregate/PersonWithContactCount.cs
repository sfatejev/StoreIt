using Domain.People;

namespace Domain.Aggregate
{
    public class PersonWithContactCount
    {
        public Person Person { get; set; }
        public int ContactCount { get; set; } 
    }
}