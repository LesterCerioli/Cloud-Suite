using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IWidgetInstanceService
  {
    Task<WindgetInstanceViewModel> GetByName(string name);

    Task Save(CreateWidgetInstanceCommand commandCreate);
  }
}