using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Country : Entity, IAggregateRoot
    {
        private readonly List<State> _states;

        public Country(Guid id)
        {
            Id = id;
            _states = new List<State>();
        }


        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? CountryName { get; set; }

        [StringLength(450)]
        public string? Code3 { get; set; }

        public bool? IsBillingEnabled { get; set; }

        public bool? IsShippingEnabled { get; set; }

        public bool? IsCityEnabled { get; set; } = true;

        public bool? IsZipCodeEnabled { get; set; } = true;

        public bool? IsDistrictEnabled { get; set; } = true;

        public IReadOnlyCollection<State> States => _states.AsReadOnly();



    }
}