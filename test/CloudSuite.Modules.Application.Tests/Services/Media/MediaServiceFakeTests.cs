using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Services.Media
{
    public class MediaServiceFakeTests
    {
        private readonly Mock<IMediaRepository> _mediaRepository;

        public MediaServiceFakeTests()
        {
            _mediaRepository = new Mock<IMediaRepository>();
        }

            
    }
}
