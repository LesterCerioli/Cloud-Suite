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
        public CustomerGroup()
        {
            CreatedOn = DateTimeOffset.Now;
            LatestUpdatedOn = DateTimeOffset.Now;
        }

        
        public Name Name { get; set; }

        public string? Description { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public DateTimeOffset? LatestUpdatedOn { get; set; }

        public IList<CustomerGroupUser> Users { get; set; } = new List<CustomerGroupUser>();
    }
}
