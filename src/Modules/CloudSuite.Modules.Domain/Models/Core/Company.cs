using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Company : Entity, IAggregateRoot
    {
        public Company(Guid id, Cnpj cnpj, string? fantasyName, string? registerName, Address address)
        {
            Id = id;
            Cnpj = cnpj;
            FantasyName = fantasyName;
            RegisterName = registerName;
            Address = address;
        }

        public Cnpj Cnpj { get; set; }

        public Guid CnpjId { get; private set; }

        public string? FantasyName { get; private set; }

        public string? RegisterName { get; private set; }

        public Address Address { get; private set; }

        public Guid AddressId { get; private set; }
    }
}
