using CloudSuite.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class CustomerGroupUser
    {
        private readonly List<User> _users;

        public CustomerGroupUser(Name name, Cpf cpf)
        {
            _users = new List<User>();
            Name = name;
            Cpf = cpf;
            _customerGroups = new List<CustomerGroup>();
        }
        
        public IReadOnlyCollection<User> Users => _users.AsReadOnly();

        public User User { get; private set; }

        public IReadOnlyCollection<CustomerGroup> CustomerGroups => _customerGroups.AsReadOnly();

        public CustomerGroup CustomerGroup { get; private set; }

        public Name Name { get; private set; }

        public Cpf Cpf { get; private set; }

        private readonly List<CustomerGroup> _customerGroups;
    }
}