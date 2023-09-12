using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class UserRole : Entity, IAggregateRoot
    {
        public virtual User User { get; set; }

        public Guid UserId { get; private set; }

        public virtual Role Role { get; set; }

        public Guid RoleId { get; private set; }
    }
}
