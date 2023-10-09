using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionalRegisterService.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Description { get; set; }
        public int? Number { get; set; }
        public string Complement { get; set; }
    }
}