using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Tests.Repositories
{
    public class CountryRepositoryTests
    {
        private readonly Mock<ICountryRepository> _countryRepoisitory;

        public CountryRepositoryTests()
        {
            _countryRepoisitory = new Mock<ICountryRepository>();
        }
    }
}
