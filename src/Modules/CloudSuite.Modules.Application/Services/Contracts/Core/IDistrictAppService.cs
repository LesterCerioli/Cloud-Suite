using CloudSuite.Modules.Application.Handlers.Core.Districts;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IDistrictAppService
    {
         Task<DistrictViewModel> GetByName(string name);

         Task Save(CreateDistrictCommand commandCreate);
    }
}