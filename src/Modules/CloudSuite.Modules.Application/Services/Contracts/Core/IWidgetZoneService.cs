using CloudSuite.Modules.Application.Handlers.Core.WidgetZones;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IWidgetZoneService
  {
    Task<WidgetZoneViewModel> GetByName(string name);

    Task Save(CreateWidgetZoneCommand commandCreate);
  }
}