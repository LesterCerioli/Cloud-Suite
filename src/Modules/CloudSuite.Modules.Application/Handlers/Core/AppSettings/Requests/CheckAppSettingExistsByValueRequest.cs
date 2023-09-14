using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests
{
  public class CheckAppSettingExistsByValueRequest : IRequest<CheckAppSettingExistsByValueResponse>
  {
    public Guid Id { get; private set; }

    public string? Value { get; set; }

    public CheckAppSettingExistsByValueRequest(string value)
    {
      Id = Guid.NewGuid();
      Value = value;
    }
  }
}