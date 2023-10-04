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
    public class AppSettingRepositoryTests
    {
        private readonly Mock<IAppSettingRepository> _appSettingRepository;

        public AppSettingRepositoryTests()
        {
            _appSettingRepository = new Mock<IAppSettingRepository>();
        }

        [Fact]
        public async Task GetByValue_ValidValue_ReturnsAppSetting()
        {
            var options = new DbContextOptionsBuilder<CloudSuiteDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new CloudSuiteDbContext(options);
            var repository = new AppSettingRepository(context);
            var testValue = "1";
            var expectedAppSetting = new AppSettingMap
            {

            };

            context.SaveChanges();
            var result = await repository.GetByValue(testValue);
            
            Assert.NotNull(result);
            Assert.Equal(testValue, result.Value);
    

        }
    }
}
