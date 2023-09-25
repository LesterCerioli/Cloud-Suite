using CloudSuite.Modules.Domain.Contracts.Core;
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
    }
}
