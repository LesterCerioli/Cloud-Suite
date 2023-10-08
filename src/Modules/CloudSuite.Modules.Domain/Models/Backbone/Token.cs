using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Backbone
{
    public class Token : Entity, IAggregateRoot
    {
        public string? Value { get; private set; }

        public Network Network { get; private set; }

        public Cpf Cpf { get; private set; }
    }
}
