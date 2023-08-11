using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Address : Entity, IAggregateRoot
    {
        public Address(Guid id)
        {
            Id = id;
        }
        
        public string? ContactName { get; set; }

        [StringLength(450)]
        public string? AddressLine1 { get; set; }

        public City City { get; set; }

        public long? CityId { get; set; }

        public long? DistrictId { get; set; }
    }
}
