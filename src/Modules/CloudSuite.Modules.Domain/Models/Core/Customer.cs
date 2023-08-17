using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Domain;
using System.Runtime.InteropServices;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id, Company company)
        {
            Id = id;
            Company = company;
            _companies = new List<Company>();
        }
        
        public Customer() { }
        
        public Company Company { get; private set; }

        private readonly List<Company> _companies;

        public Guid CompanyId { get; private set; }

        public IReadOnlyCollection<Company> Companies => _companies.AsReadOnly();

        public Cnpj Cnpj { get; private set; }




    }
}