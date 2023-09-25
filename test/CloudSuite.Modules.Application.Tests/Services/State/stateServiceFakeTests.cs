using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Services.State
{
    public class StateServiceFakeTests
    {
        private readonly Mock<IStateRepository> _stateRepository;

        public StateServiceFakeTests()
        {
            _stateRepository = new Mock<IStateRepository>();

        }
    }
}
