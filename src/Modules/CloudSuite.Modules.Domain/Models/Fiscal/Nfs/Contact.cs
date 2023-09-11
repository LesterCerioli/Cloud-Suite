using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.ValueObjects;
namespace CloudSuite.Modules.Domain.Models.Fiscal.Nfs
{
    public class Contact : Entity, IAggregateRoot
    {
        public Telephone Telephone { get; private set; }

        public Email Email { get; private set; }
        
    }
}