using NetDevPack.Domain;
using System;

namespace CloudSuite.Modules.Core.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string? firstName, string? middleName, string? lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
        
    }
}