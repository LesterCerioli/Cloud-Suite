using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class SettingService : ISettingService
    {
       // private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<SettingService> _logger;
        private readonly IConfiguration _configuration;
        
        public SettingService(
            //ISettingRepository settingRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<SettingService> logger,
            IConfiguration configuration)
        {
           // _settingRepository = settingRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        public Task<Dictionary<string, string>> GetAllSettingsAsync()
        {
            //_logger.LogInformation($"Getting Media By Filename: {fileName}");
            //return _mapper.Map<>(await _mediaRepository.GetByFileName(fileName));
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, string>> GetAllSettingsForUserAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSettingValueAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSettingValueForUserAsync(long userId, string name)
        {
            throw new NotImplementedException();
        }

    }
}
