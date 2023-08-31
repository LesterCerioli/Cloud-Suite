using CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests;
using CloudSuite.Modules.Application.Validations.Core.Vendores;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores
{
  public class CheckVendorExistsByCreationDateHandlers : IRequestHandler<CheckVendorExistsByCreationDateRequest, CheckVendorExistsByCreationDateResponse>
  {
    private IVendorRepository _vendorRepository;
    private readonly ILogger<CheckVendorExistsByCreationDateHandlers> _logger;
    public CheckVendorExistsByCreationDateHandlers(IVendorRepository vendorRepository, ILogger<CheckVendorExistsByCreationDateHandlers> logger)
    {
      _vendorRepository = vendorRepository;
      _logger = logger;

    }

    public async Task<CheckVendorExistsByCreationDateResponse> Handle(CheckVendorExistsByCreationDateRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckVendorExistsByCreationDateRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckVendorExistsByCreationDateRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var vendor = await _vendorRepository.GetByCreationDate(request.CreatedOn);

          if (vendor != null)
            return await Task.FromResult(new CheckVendorExistsByCreationDateResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckVendorExistsByCreationDateResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckVendorExistsByCreationDateResponse(request.Id, false, validationResult));
    }
  }
}