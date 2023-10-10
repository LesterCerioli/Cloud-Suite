using MediatR;
using CloudSuite.Modules.Core.Application.Core;

namespace CloudSuite.Modules.Core.Application.Handlers.Addresses
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

        

        

    }
}