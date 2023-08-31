using CloudSuite.Modules.Application.Handlers.Core.Addresses.Responses;
using AddressEntity = CloudSuite.Modules.Domain.Models.Core.Address;
using CloudSuite.Modules.Domain.Models.Core;
using MediatR;
namespace CloudSuite.Modules.Application.Handlers.Core.Addresses
{
  public class CreateAddressCommand : IRequest<CreateAddressResponse>
  {
    public CreateAddressCommand()
    {
      Id = Guid.NewGuid();
    }

    public AddressEntity GetEntity()
    {
      return new AddressEntity(
        this.Id
      );
    }

    public Guid Id { get; private set; }

    public string? ContactName { get; set; }

    public string? AddressLine1 { get; set; }

    public City? City { get; set; }
  }
}