using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Tests.Repositories
{
    public class DistrictRepositoryTests
    {
        private readonly Mock<IDistrictRepository> _districtRepository;

        public DistrictRepositoryTests() 
        {
            _districtRepository = new Mock<IDistrictRepository>();
        }
    }
}
