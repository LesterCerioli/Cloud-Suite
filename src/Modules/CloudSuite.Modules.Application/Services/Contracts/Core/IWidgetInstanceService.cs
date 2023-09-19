using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IWidgetInstanceService
  {
    Task<WidgetInstanceViewModel> GetByName(string name);

    Task<WidgetInstanceViewModel> GetByDisplayOrder(int displayOrder);
    
    Task<WidgetInstanceViewModel> GetByData(string data);

    Task Save(CreateWidgetInstanceCommand commandCreate);
  }
}