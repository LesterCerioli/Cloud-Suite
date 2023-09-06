using CloudSuite.Modules.Application.Handlers.Core.Countries;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  internal interface ICountryService
  {
    Task<CountryViewModel> GetByName(string countryName);

    Task Save(CreateCountryCommand commandCreate);
  }
}