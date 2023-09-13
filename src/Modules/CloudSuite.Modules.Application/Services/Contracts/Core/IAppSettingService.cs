using CloudSuite.Modules.Application.Handlers.Core.AppSettings;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IAppSettingService
  {
        Task<AppSettingViewModel> GetByAppSetting(string value);
        Task<AppSettingViewModel> GetByModule(string module);

        Task Save(CreateAppSettingCommand commandCreate);
  }
}