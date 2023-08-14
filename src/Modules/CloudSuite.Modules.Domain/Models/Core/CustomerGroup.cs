using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class CustomerGroup : Entidade, IAggregateRoot
    {
             
        public CustomerGroup() { }

        public CustomerGroup(string? name, string? description, bool? isActive, bool? isDeleted, DateTimeOffset? createdOn, DateTimeOffset? latestUpdatedOn)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            IsDeleted = isDeleted;
            CreatedOn = DateTimeOffset.Now;
            LatestUpdatedOn = DateTimeOffset.Now;
            _customerGroupUsers = new List<CustomerGroupUser>();

        }

        public string? Name { get; private set; }

        public string? Description { get; private set; }

        public bool? IsActive { get; private set; }

        public bool? IsDeleted { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public DateTimeOffset? LatestUpdatedOn { get; private set; }

        private readonly List<CustomerGroupUser> _customerGroupUsers;

        public CustomerGroupUser CustomerGroupUsers { get; private set; }

        public IReadOnlyCollection<CustomerGroupUser> CustomerGroupUser => _customerGroupUsers.AsReadOnly();
    }
}
