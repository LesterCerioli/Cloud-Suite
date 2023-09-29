using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Services.Implementations
using CloudSuite.Modules.Application.Services.Contracts;

namespace CloudSuite.Modules.Application.Tests.Services.User
{
    public class UserServiceFakeTests
    {
        private readonly Mock<IUserService> _userService;

        public UserServiceFakeTests()
        {
            _userService = new Mock<IUserService>();
        }
        
    }
}