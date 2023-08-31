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

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? ContactName { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? AddressLine1 { get; private set; }

        public City City { get; private set; }

        public District District { get; private set; }

        public Guid DistrictId { get; private set; }

        public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();

        public IReadOnlyCollection<District> Districts => _districts.AsReadOnly();


    }
}
