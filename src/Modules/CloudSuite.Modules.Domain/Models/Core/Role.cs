using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class Role : Entity, IAggregateRoot
    {
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
