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
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<MediaService> _logger;
        private readonly IConfiguration _configuration;
        
        public MediaService(
            IMediaRepository mediaRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<MediaService> logger,
            IConfiguration configuration)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<Media> GetByFileName(string fileName)
        {
            _logger.LogInformation($"Getting Media By Filename: {fileName}");
            return _mapper.Map<Media>(await _mediaRepository.GetByFileName(fileName));
        }

        public async Task<Media> GetByFileSize(int fileSize)
        {
            _logger.LogInformation($"Getting Media By Filesize: {fileSize}");
            return _mapper.Map<Media>(await _mediaRepository.GetByFileSize(fileSize));
        }
    }
}
