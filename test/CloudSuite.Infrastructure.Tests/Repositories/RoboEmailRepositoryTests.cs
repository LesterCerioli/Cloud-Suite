

using CloudSuite.Infrastructure.Data.Core.Context;
using CloudSuite.Infrastructure.Data.Mappimgs.EFCore.Core;
using CloudSuite.Infrastructure.Data.Repositories.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Tests.Repositories
{
    public class RoboEmailRepositoryTests
    {
        private readonly Mock<IRoboEmailRepository> _roboEmailRepository;
        private readonly object roboEmail;
        private readonly CloudSuiteDbContext context;

        public RoboEmailRepositoryTests()
        {
            _roboEmailRepository = new Mock<IRoboEmailRepository>();

        }

        [Fact]
        public async Task GetBySubject_ValidName_ReturnsRoboEmail()
        {
            var options = new DbContextOptionsBuilder<CloudSuiteDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new CloudSuiteDbContext(options);
            var repository = new RoboEmailRepository(context);
            var testSubject = "Email de Teste";
            var expectedState = new RoboEmailMap
            {

            };

            context.SaveChanges();
            var result = await repository.GetBySubject(testSubject);
            Assert.NotNull(result);
            Assert.Equal(testSubject, result.Subject);


        }
        [Fact]
        public async Task GetByReceivedTime_ShouldReturnRoboEmail()
        {
            var options = new DbContextOptionsBuilder<CloudSuiteDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            
            var receivedTime = DateTimeOffset.Now;

            var repository = new RoboEmailRepository(context);
                        

        }


    }
}
