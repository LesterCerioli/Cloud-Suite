using CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests
{
  public class CheckVendorExistsByCnpjRequest : IRequest<CheckVendorExistsByCnpjResponse>
  {
    public Guid Id { get; private set; }  

    public Cnpj Cnpj { get; set; }
    
    public CheckVendorExistsByCnpjRequest(Cnpj cnpj)
    {
      Id = Guid.NewGuid();
      Cnpj = cnpj;
    }
  }
}