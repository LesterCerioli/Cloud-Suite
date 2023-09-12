using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IAppSettingService
  {
    Task<AppSettingViewModel> GetByAppSetting(string value);

    Task Save(CreateAppSettingCommand commandCreate);
  }
}