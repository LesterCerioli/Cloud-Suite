using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Country : Entity, IAggregateRoot
    {
        private readonly List<State> _states;

        
        public Country(Guid id, string? countryName, string? code3, bool? isBillingEnabled, bool? isShippingEnabled, bool? isCityEnabled, bool? isZipCodeEnabled, bool? isDistrictEnabled)
        {
            Id = id;
            CountryName = countryName;
            Code3 = code3;
            IsBillingEnabled = isBillingEnabled;
            IsShippingEnabled = isShippingEnabled;
            IsCityEnabled = isCityEnabled;
            IsZipCodeEnabled = isZipCodeEnabled;
            IsDistrictEnabled = isDistrictEnabled;
            _states = new List<State>();
        }

        public Country() { }
        
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? CountryName { get; private set; }

        [StringLength(450)]
        public string? Code3 { get; private set; }

        public bool? IsBillingEnabled { get; private set; }

        public bool? IsShippingEnabled { get; private set; }

        public bool? IsCityEnabled { get; private set; } = true;

        public bool? IsZipCodeEnabled { get; private set; } = true;

        public bool? IsDistrictEnabled { get; private set; } = true;

        public IReadOnlyCollection<State> States => _states.AsReadOnly();

        public Guid StateId { get; private set; }



    }
}