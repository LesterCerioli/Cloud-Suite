using CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests;
using CloudSuite.Modules.Application.Validations.Core.Vendores;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores
{
  public class CheckVendorExistsByNameHandlers : IRequestHandler<CheckVendorExistsByNameRequest, CheckVendorExistsByNameResponse>
  {
    private IVendorRepository _vendorRepository;
    private readonly ILogger<CheckVendorExistsByNameHandlers> _logger;
    public CheckVendorExistsByNameHandlers(IVendorRepository vendorRepository, ILogger<CheckVendorExistsByNameHandlers> logger)
    {
      _vendorRepository = vendorRepository;
      _logger = logger;
      
    }

    public async Task<CheckVendorExistsByNameResponse> Handle(CheckVendorExistsByNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckVendorExistsByNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckVendorExistsByNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var vendor = await _vendorRepository.GetByName(request.Name);

          if (vendor != null)
          return await Task.FromResult(new CheckVendorExistsByNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckVendorExistsByNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckVendorExistsByNameResponse(request.Id, false, validationResult));
    }
  }
} 