using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Core.Medias;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class MediaService : IMediaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IMediaRepository _mediaRepository;

        public MediaService(
            IMapper mapper,
            IMediaRepository mediaRepository,
            IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _mediaRepository = mediaRepository;
        }
        public async Task<MediaViewModel> GetByFileName(string fileName)
        {
            return _mapper.Map<MediaViewModel>(await _mediaRepository.GetByFileName(fileName));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
        public async Task Save(CreateMediaCommand commandCreate)
        {
            await _mediaRepository.Add(commandCreate.GetEntity());
        }
    }
}
