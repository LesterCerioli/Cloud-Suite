using CloudSuite.Infrastructure.Models;
using CloudSuite.Modules.Domain.ValueObjects;


namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Customer : EntityBase
    {
        public Customer(long id)
        {
            Id = id;
        }
        
        public Name Name { get; set; }


    }
}