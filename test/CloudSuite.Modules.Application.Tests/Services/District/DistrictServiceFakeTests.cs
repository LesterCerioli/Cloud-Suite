using AutoMapper;
using CloudSuite.Modules.Application.AutoMapper;
using CloudSuite.Modules.Application.Handlers.Core.Districts;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.Services.Implementations.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Tests.Models;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Services.District
{
    public class DistrictServiceFakeTests 
    {
        private readonly Mock<IDistrictRepository> _districtRepository;

        public DistrictServiceFakeTests()
        {
            _districtRepository = new Mock<IDistrictRepository>();

        }
    }
}
