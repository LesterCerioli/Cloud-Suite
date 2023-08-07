using CloudSuite.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Country : EntityBase
    {
        public Country(long id)
        {
            Id = id;
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

        public IList<State> States { get; set; } = new List<State>();



    }
}