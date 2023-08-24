using CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests
{
  public class CheckVendorExistsByCreationDateRequest : IRequest<CheckVendorExistsByCreationDateResponse>
  {
    public Guid Id { get; private set; }  
    public DateTimeOffset CreatedOn { get; private set; }
    public CheckVendorExistsByCreationDateRequest(DateTimeOffset createdOn)
    {
      Id = Guid.NewGuid();
      CreatedOn = createdOn;
    }
  }
}