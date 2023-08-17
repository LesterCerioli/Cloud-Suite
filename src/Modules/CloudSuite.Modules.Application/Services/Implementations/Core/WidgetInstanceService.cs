using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetDevPack.Data;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class WidgetInstanceService : IWidgetInstanceService
    {
        private readonly IWidgetRepository _widgetRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<WidgetInstanceService> _logger;
        private readonly IConfiguration _configuration;

        public WidgetInstanceService(
            IWidgetRepository widgetRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<WidgetInstanceService> logger,
            IConfiguration configuration)
        {
            _widgetRepository = widgetRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<Widget> GetByCreationDate(DateTimeOffset creationDate)
        {
            _logger.LogInformation($"Getting Widget By Creation Date: {creationDate}");
            return _mapper.Map<Widget>(await _widgetRepository.GetByCreationDate(creationDate));
        }

        public async Task<Widget> GetByEditUrl(string editUrl)
        {
            _logger.LogInformation($"Getting Widget By Edit Url: {editUrl}");
            return _mapper.Map<Widget>(await _widgetRepository.GetByEditUrl(editUrl));
        }

        public async Task<Widget> GetByLatestUpdatedDate(string createUrl)
        {
             _logger.LogInformation($"Getting Widget By Latest Updated Date: {createUrl}");
            return _mapper.Map<Widget>(await _widgetRepository.GetByEditUrl(createUrl));
        }

        public async Task<Widget> GetByName(string name)
        {
             _logger.LogInformation($"Getting Widget By Name: {name}");
            return _mapper.Map<Widget>(await _widgetRepository.GetByName(name));
        }
    }
}
