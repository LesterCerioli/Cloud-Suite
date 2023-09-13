using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IWidgetInstanceService
  {
        Task<WindgetInstanceViewModel> GetByName(string name);

        Task<WindgetInstanceViewModel> GetByWidgetId(string widgetId);

        Task<WindgetInstanceViewModel> GetByDisplayOrder(int displayOrder);

        Task<WindgetInstanceViewModel> GetByData(string data);

        Task<WindgetInstanceViewModel> GetByHtmlData(string htmlData);

        Task Save(CreateWidgetInstanceCommand commandCreate);
  }
}