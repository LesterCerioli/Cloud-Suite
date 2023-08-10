using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;
using AddressEntity = CloudSuite.Modules.Domain.Models.Core.Address;

namespace CloudSuite.Modules.Application.Handlers.Core.Addresses
{
    public class CreateAddressCommand : IRequest<>
    {
    }
}
