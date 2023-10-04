using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Services.User
{
    public class UserServiceFakeTests
    {
        private readonly Mock<IUserRepository> _userRepository;

        public UserServiceFakeTests()
        {
            _userRepository = new Mock<IUserRepository>();
        }
    }
}
