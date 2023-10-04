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
    public class DistrictRepositoryTests
    {
        private readonly Mock<IDistrictRepository> _districtRepository;

        public DistrictRepositoryTests() 
        {
            _districtRepository = new Mock<IDistrictRepository>();
        }

        [Fact]
        public async Task GetByName_ValidName_ReturnsDistrict()
        {
            var options = new DbContextOptionsBuilder<CloudSuiteDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new CloudSuiteDbContext(options);
            var repository = new DistrictRepository(context);
            var testName = "Copacabana";
            var expectedCity = new DistrictMap
            {

            };

            context.SaveChanges();
            var result = await repository.GetByName(testName);
            Assert.NotNull(result);
            Assert.Equal(testName, result.Name);


        }


    }
}
