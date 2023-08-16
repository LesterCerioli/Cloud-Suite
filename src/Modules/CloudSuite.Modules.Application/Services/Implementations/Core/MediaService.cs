using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using NetDevPack.Data;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        
        public MediaService(
            IMediaRepository mediaRepository,
            IMediatorHandler mediator,
            IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Media> GetByFileName(string fileName)
        {
            return _mapper.Map<Media>(await _mediaRepository.GetByFileName(fileName));
        }

        public async Task<Media> GetByFileSize(int fileSize)
        {
            return _mapper.Map<Media>(await _mediaRepository.GetByFileSize(fileSize));
        }
    }
}
