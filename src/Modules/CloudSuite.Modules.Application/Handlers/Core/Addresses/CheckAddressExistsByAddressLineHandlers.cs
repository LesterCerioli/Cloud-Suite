using CloudSuite.Modules.Application.Handlers.Core.Addresses.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Addresses.Requests;
using CloudSuite.Modules.Application.Validations.Core.Addresses;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Addresses
{
    public class CheckAddressExistsByAddressLineHandlers :IRequestHandler<CheckAddressExistsByAddressLineRequest, CheckAddressExistsByAddressLineResponse>
    {
        private IAddressRepository _addressRepository;
        private readonly ILogger<CheckAddressExistsByAddressLineHandlers> _logger;
        public CheckAddressExistsByAddressLineHandlers(IAddressRepository addressRepository, ILogger<CheckAddressExistsByAddressLineHandlers> logger)
        {
            _addressRepository = addressRepository;
            _logger = logger;
        }

        public async Task<CheckAddressExistsByAddressLineResponse> Handle(CheckAddressExistsByAddressLineRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckAddressExistsByAddressLineRequest: {JsonSerializer.Serialize(request)}");

            var validationResult = new CheckAddressExistsByAddressLineRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var address = await _addressRepository.GetByAddressLine(request.AddressLine1);

                    if (address != null)
                    return await Task.FromResult(new CheckAddressExistsByAddressLineResponse(request.Id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckAddressExistsByAddressLineResponse(request.Id, "Não foi possivel processar a solicitação"));
                }
            }
            return await Task.FromResult(new CheckAddressExistsByAddressLineResponse(request.Id, false, validationResult));
        }
    }
}
