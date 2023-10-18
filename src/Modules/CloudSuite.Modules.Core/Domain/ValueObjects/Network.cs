using NetDevPack.Domain;
using System;

namespace CloudSuite.Modules.Core.Domain.ValueObjects
{
    public class Network : ValueObject
    {
        public string IpAddress { get; set; }

        public string? MacAddress { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
        
    }
}