using CloudSuite.Modules.Application.Handlers.Core.Widgets;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IWidgetService
  {
    Task<WidgetViewModel> GetByName(string name);

    Task<WidgetViewModel> GetByCreationDate(DateTimeOffset creationDate);

    Task Save(CreateWidgetCommand commandCreate);
  }
}