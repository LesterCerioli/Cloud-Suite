using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Common.ValueObjects
{
	public class Customer : ValueObject
	{
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
		{
			throw new NotImplementedException();
		}
	}
}
