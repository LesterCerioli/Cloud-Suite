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
        private readonly List<District> _districts = new List<District>();

        private readonly List<City> _cities = new List<City>();

        public Address(Guid id)
        {
            Id = id;
            _districts = new List<District>();
            _cities = new List<City>();
        }
        
        public string? ContactName { get; set; }

        [StringLength(450)]
        public string? AddressLine1 { get; set; }

        public City City { get; set; }

        public District District { get; set; }

        public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();

        public IReadOnlyCollection<District> Districts => _districts.AsReadOnly();


    }
}
