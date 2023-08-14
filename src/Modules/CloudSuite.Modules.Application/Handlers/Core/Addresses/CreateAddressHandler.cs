using CloudSuite.Modules.Application.Handlers.Core.Addresses.Responses;
using CloudSuite.Modules.Application.Validations.Core.Addresses;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

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

            if (validationResult.IsValid)
            {
                try 
                {
                    var address = await _addressRepository.GetByAddressLine(command.AddressLine1);

                    if (address != null)
                    return await Task.FromResult(new CreateAddressResponse(command.Id, "Endereço já cadastrado"));

                    await _addressRepository.Add(command.GetEntity());

                    return await Task.FromResult(new CreateAddressResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);

                    return await Task.FromResult(new CreateAddressResponse(command.Id, "Não foi possivel processar a solicitação."));
                }
            }

            return await Task.FromResult(new CreateAddressResponse(command.Id, validationResult));
        }
    }
}
