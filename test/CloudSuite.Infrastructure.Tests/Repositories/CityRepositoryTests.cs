using CloudSuite.Infrastructure.Data.Core.Context;
using CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Core;
using CloudSuite.Infrastructure.Data.Repositories.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.EntityFrameworkCore;
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

        [Fact]
        public async Task GetByCityName_ValidCityName_ReturnsCity()
        {
            var options = new DbContextOptionsBuilder<CloudSuiteDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new CloudSuiteDbContext(options);
            var repository = new CityRepository(context);
            var testCityName = "Curitiba";
            var expectedCity = new CityMap
            {

            };

            context.SaveChanges();
            var result = await repository.GetByCityName(testCityName);
            Assert.NotNull(result);
            Assert.Equal(testCityName, result.CityName);


        }
    }
}
