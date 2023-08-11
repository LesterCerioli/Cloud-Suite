using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class City : Entity, IAggregateRoot
    {
        public City(Guid id)
        {
            Id = id;
        }
        
        public string? CityName { get; set; }

        public long? StateId { get; set; }

        public State State { get; set; }
    }
}
