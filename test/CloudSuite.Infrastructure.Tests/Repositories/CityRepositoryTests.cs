using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Tests.Repositories
{
    public class CityRepositoryTests
    {
        private readonly Mock<ICityRepository> _cityRepository;

        public CityRepositoryTests()
        {
            _cityRepository = new Mock<ICityRepository>();
        }
    }
}
