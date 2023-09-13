using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Responses;
using AppSettingEntity = CloudSuite.Modules.Domain.Models.Core.AppSetting;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.AppSettings
{
  public class CreateAppSettingCommand : IRequest<CreateAppSettingResponse>
  {
    public CreateAppSettingCommand()
    {
      Id = Guid.NewGuid();
    }

    public AppSettingEntity GetEntity()
    {
      return new AppSettingEntity(
        this.Id
      );
    }

    public Guid Id { get; private set; }

    public string? Value { get; set; }

    public string? Module { get; set; }

    public bool? IsVisibleInCommonSettingPage { get; set; }
  }
}