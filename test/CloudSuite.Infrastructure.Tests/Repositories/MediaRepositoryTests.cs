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
    public class MediaRepositoryTests
    {
        private readonly Mock<IMediaRepository> _mediaRepository;

        public MediaRepositoryTests()
        {
            _mediaRepository = new Mock<IMediaRepository>();
        }

        [Fact]
        public async Task GetByFileName_ValidName_ReturnsMedia()
        {
            var options = new DbContextOptionsBuilder<CloudSuiteDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new CloudSuiteDbContext(options);
            var repository = new MediaRepository(context);
            var testFileName = "testefile";
            var expectedCity = new MediaMap
            {

            };

            context.SaveChanges();
            var result = await repository.GetByFileName(testFileName);
            Assert.NotNull(result);
            Assert.Equal(testFileName, result.FileName);


        }


    }
}
