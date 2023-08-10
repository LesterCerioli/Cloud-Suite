using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CloudSuite.Modules.Application.ViewModels.Core
{
    public class CountryForm
    {
        [Required(ErrorMessage = "The {0} field is required.")]

        public string Id { get; set; }

        public string Name { get; set; }

        public string Conde3 { get; set;}

        public bool IsBillingEnabled { get; set; }

        public bool IsShippingEnabled { get; set; }

        public bool IsCityEnabled { get; set; }

        public bool IsZipCodeEnabled { get; set; }

        public bool IsDistrictEnabled { get; set; }

    }
}
