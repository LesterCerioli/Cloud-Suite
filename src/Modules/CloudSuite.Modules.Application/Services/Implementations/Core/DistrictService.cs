using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Core.Districts;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class DistrictService : IDistrictService
    {
        private readonly IMediatorHandler _mediator;
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;

        public DistrictService(
            IDistrictRepository districtRepository,
            IMapper mapper,
            IMediatorHandler mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _districtRepository = districtRepository;
        }


        public async Task<DistrictViewModel> GetByName(string name)
        {
            return _mapper.Map<DistrictViewModel>(await _districtRepository.GetByName(name));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
        public async Task Save(CreateDistrictCommand commandCreate)
        {
            await _districtRepository.Add(commandCreate.GetEntity());
        }
    }
}