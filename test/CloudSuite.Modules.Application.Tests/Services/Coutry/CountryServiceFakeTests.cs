using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Core.Countries;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.Services.Implementations.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Moq;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Services.Coutry
{
    public class CountryServiceFakeTests 
    {
        private readonly Mock<ICountryRepository> _countryRepository;

        public CountryServiceFakeTests()
        {
            _countryRepository = new Mock<ICountryRepository>();
        }
    }
}
