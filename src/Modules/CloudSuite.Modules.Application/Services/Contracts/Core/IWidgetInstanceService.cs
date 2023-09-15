using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IWidgetInstanceService
  {
    Task<WindgetInstanceViewModel> GetByName(string name);

    Task<WindgetInstanceViewModel> GetByDisplayOrder(int displayOrder);
    
    Task<WindgetInstanceViewModel> GetByData(string data);

    Task Save(CreateWidgetInstanceCommand commandCreate);
  }
}