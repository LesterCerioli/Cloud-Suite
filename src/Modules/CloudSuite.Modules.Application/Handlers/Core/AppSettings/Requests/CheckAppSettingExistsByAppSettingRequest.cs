using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Handlers.Core.AppSettings.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.AppSettings.Requests
{
  public class CheckAppSettingExistsByAppSettingRequest : IRequest<CheckAppSettingExistsByAppSettingResponse>
  {
    public Guid Id { get; private set; }

    public string? Value { get; private set; }

    public CheckAppSettingExistsByAppSettingRequest(string value)
    {
      Id = Guid.NewGuid();
      Value = value;
    }
  }
}