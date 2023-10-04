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
    public class StateRepositoryTests
    {
        private readonly Mock<IStateRepository> _stateRepository;

        public StateRepositoryTests()
        {
            _stateRepository = new Mock<IStateRepository>();
        }

        [Fact]
        public async Task GetByName_ValidName_ReturnsState()
        {
            var options = new DbContextOptionsBuilder<CloudSuiteDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new CloudSuiteDbContext(options);
            var repository = new StateRepository(context);
            var testName = "Rio de Janeiro";
            var expectedState = new StateMap
            {

            };

            context.SaveChanges();
            var result = await repository.GetByName(testName);
            Assert.NotNull(result);
            Assert.Equal(testName, result.StateName);


        }
    }
}
