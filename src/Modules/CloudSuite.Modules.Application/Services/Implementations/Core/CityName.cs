using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Core.Cities;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using MediatR;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public class CityName : ICityService
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly IMediatorHandler _mediator;

        public CityName(
            
            ICityRepository cityRepository,
            IMediatorHandler mediator,
            IMapper mapper
        )

        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _mediator = mediator;                
        }

        public async Task<CityViewModel> GetByCityName(string cityName)
        {
            return _mapper.Map<CityViewModel>(await _cityRepository.GetByCityName(cityName));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateCityCommand commandCreate)
        {
            await _cityRepository.Add(commandCreate.GetEntity());
        }
    }
}