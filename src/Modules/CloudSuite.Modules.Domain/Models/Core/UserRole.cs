using Microsoft.AspNetCore.Identity;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Core
{
    public class UserRole : IdentityUserRole<long>, IAggregateRoot
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
