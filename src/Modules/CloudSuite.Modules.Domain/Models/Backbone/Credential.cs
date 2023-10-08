using CloudSuite.Modules.Common.Enums.Backbone;
using CloudSuite.Modules.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Models.Backbone
{
    public class Credential : Entity, IAggregateRoot
    {
        public Credential(string? login, string? password, Network network)
        {
            Login = login;
            Password = password;
            Network = network;
        }

        public string? Login { get; private set; }

        public string? Password { get; private set; }

        public Network Network { get; private set; }

        public AccessLevel AccessLevel { get; private set; }

        public Cpf Cpf { get; private set; }
    }
}
