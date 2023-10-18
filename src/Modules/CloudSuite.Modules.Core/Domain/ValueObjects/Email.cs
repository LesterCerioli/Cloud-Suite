using NetDevPack.Domain;
using System;

namespace CloudSuite.Modules.Core.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string? EmailAddress { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
        
    }
}