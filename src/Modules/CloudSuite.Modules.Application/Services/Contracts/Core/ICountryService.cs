using CloudSuite.Modules.Application.Handlers.Core.Countries;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface ICountryService
  {
        Task<CountryViewModel> GetByName(string countryName);

        Task<CountryViewModel> GetByCode(string code3);

        Task Save(CreateCountryCommand commandCreate);
  }
}