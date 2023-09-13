using CloudSuite.Modules.Application.Handlers.Core.Countries;
using CloudSuite.Modules.Application.ViewModels.Core;
using MediatR;
using NetDevPack.Mediator;
using AutoMapper;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Domain.Application.Core;


namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        private readonly IMediatorHandler _mediatorHandler;
        public CountryService(
            IMapper mapper,
            ICountryRepository countryRepository,
            IMediatorHandler mediatorHandler
        )
        {

            _mapper = mapper;
            _countryRepository = countryRepository;
            _mediator = mediatorHandler;
        }
        public async Task<CountryViewModel> GetByName(string name)
        {
            return _mapper.Map<CountryViewModel>(await _countryRepository.GetByName(name));
        }
        
        public async Task<CountryViewModel> GetByCode(string code3)
        {
            return _mapper.Map<CountryViewModel>(await _countryRepository.GetByCode(code3));
        }

         public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save(CreateCountryCommand commandCreate)
        {
            await _countryRepository.Add(commandCreate.GetEntity());
        }
    }
}