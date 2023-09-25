using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Tests.Repositories
{
    public class AddressRepositoryTests
    {
        private readonly Mock<IAddressRepository> _addressRepository;

        public AddressRepositoryTests()
        {
            _addressRepository = new Mock<IAddressRepository>();
        }
    }
}
