using CloudSuite.Modules.Domain.Contracts.Core;
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
    }
}
