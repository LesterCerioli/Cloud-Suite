

using CloudSuite.Modules.Application.Handlers.Core.Addresses.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Addresses.Requests
{
  public class CheckAddressExistsByContactNameRequest : IRequest<CheckAddressExistsByContactNameResponse>
  {
    public Guid Id { get; private set; }

    public string? ContactName { get; set; }

    public CheckAddressExistsByContactNameRequest(string contactName)
    {
      Id = Guid.NewGuid();
      ContactName = contactName;
    }
  }
}