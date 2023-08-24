using CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests
{
  public class CheckVendorExistsByNameRequest : IRequest<CheckVendorExistsByNameResponse>
  {
    public Guid Id { get; private set; }  
    public string? Name { get; private set; }
    public CheckVendorExistsByNameRequest(string? name)
    {
      Id = Guid.NewGuid();
      Name = name;
    }
  }
}