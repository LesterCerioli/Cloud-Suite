using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests
{
  public class CheckAppSettingExistsByModuleRequest : IRequest<CheckAppSettingExistsByModuleResponse>
  {
    public Guid Id { get; private set; }

    public string? Module { get; private set; }

    public CheckAppSettingExistsByModuleRequest(string module)
    {
      Id = Guid.NewGuid();
      Module = module;
    }
  }
}