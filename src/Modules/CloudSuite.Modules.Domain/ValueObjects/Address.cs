using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
