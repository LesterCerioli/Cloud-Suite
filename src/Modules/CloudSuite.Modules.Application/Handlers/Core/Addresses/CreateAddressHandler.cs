using System.Reflection.Metadata;
using System.Text.Json;
using CloudSuite.Modules.Application.Handlers.Core.Addresses;
using CloudSuite.Modules.Application.Handlers.Core.Addresses.Responses;
using CloudSuite.Modules.Domain.Contracts.Core;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CloudSuite.Modules.Application.Handlers.Core.Addresses
{
    public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, CreateAddressResponse>
    {
        private IAddressRepository _addressRepository;
        private readonly ILogger<CreateAddressHandler> _logger;
        public CreateAddressHandler(IAddressRepository addressRepository, ILogger<CreateAddressHandler> logger)
        {
            _addressRepository = addressRepository;
            _logger = logger;
        }

        public async Task<CreateAddressResponse> Handle(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateAddressCommand: {JsonSerializer.Serialize(command)}");

            var validationResult = new CreateAddressCommandValidation().Validate(command);
        }
    }
}
