using CloudSuite.Modules.Application.Handlers.Core.Addresses.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Addresses.Requests;
using CloudSuite.Modules.Application.Validations.Core.Addresses;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;
namespace CloudSuite.Modules.Application.Handlers.Core.Addresses
{
  public class CheckAddressExistsByContactNameHandlers : IRequestHandler<CheckAddressExistsByContactNameRequest, CheckAddressExistsByContactNameResponse>
  {
    private IAddressRepository _addressRepository;
    private readonly ILogger<CheckAddressExistsByContactNameHandlers> _logger;
    public CheckAddressExistsByContactNameHandlers(IAddressRepository addressRepository, ILogger<CheckAddressExistsByContactNameHandlers> logger)
    {
      _addressRepository = addressRepository;
      _logger = logger;
    }
    public async Task<CheckAddressExistsByContactNameResponse> Handle(CheckAddressExistsByContactNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckAddressExistsByContactNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckAddressExistsByContactNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var address = await _addressRepository.GetByContactName(request.ContactName);

          if (address != null)
            return await Task.FromResult(new CheckAddressExistsByContactNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckAddressExistsByContactNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckAddressExistsByContactNameResponse(request.Id, false, validationResult));
    }
  }
}