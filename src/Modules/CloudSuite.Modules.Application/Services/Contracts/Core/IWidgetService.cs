using CloudSuite.Modules.Application.Handlers.Core.Widgets;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IWidgetService
  {
        Task<WidgetViewModel> GetByName(string name);

        Task<WidgetViewModel> GetByCreationDate(DateTimeOffset creationDate);

        Task<WidgetViewModel> GetByLatestUpdatedDate(string createUrl);

        Task<WidgetViewModel> GetByEditUrl(string editUrl);

        Task Save(CreateWidgetCommand commandCreate);
  }
}