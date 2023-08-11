using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Domain;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id)
        {
            Id = id;
        }
        
        public Name Name { get; set; }


    }
}