using System.ComponentModel;
using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Backbone
{
    public class SystemAccess : Entity, IAggregateRoot
    {
        public SystemAccess(string? name, bool? isProper, DateTime? createdOn)
        {
            Name = name;
            IsProper = isProper;
            CreatedOn = DateTimeOffset.Now;
        }

        public string? Name { get; private set; }

        public bool? IsProper { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public Cpf Cpf { get; private set; }
    }
}
