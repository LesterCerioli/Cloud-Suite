using CloudSuite.Modules.Application.Handlers.Core.Cities;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  internal interface ICityService
  {
    Task<CityViemModel> GetByCityName(string cityName);

    Task Save(CreateCityCommand commandCreate);
  }
}