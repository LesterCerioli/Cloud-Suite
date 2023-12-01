using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Domain.Models
{
	public class TransferFilter : Entity, IAggregateRoot
	{
        public DateTime? StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public string? Page { get; private set; }


    }
}
