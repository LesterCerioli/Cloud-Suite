using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Services.City
{
    public class CityServiceFakeTests
    {
        private readonly Mock<ICityRepository> _cityRepository;

        public CityServiceFakeTests()
        {
            _cityRepository = new Mock<ICityRepository>();
        }
    }
}
