using CloudSuite.Modules.Application.Handlers.Core.WidgetZones;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IWidgetZoneService
  {
        Task<WidgetZoneViewModel> GetByName(string name);
        Task<WidgetZoneViewModel> GetByDescription(string description);

        Task Save(CreateWidgetZoneCommand commandCreate);
  }
}