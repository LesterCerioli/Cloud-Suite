using CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests;
using CloudSuite.Modules.Application.Validations.Core.Vendores;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores
{
  public class CheckVendorExistsByCnpjHandlers : IRequestHandler<CheckVendorExistsByCnpjRequest, CheckVendorExistsByCnpjResponse>
  {
    private IVendorRepository _vendorRepository;
    private readonly ILogger<CheckVendorExistsByCnpjHandlers> _logger;
    public CheckVendorExistsByCnpjHandlers(IVendorRepository vendorRepository, ILogger<CheckVendorExistsByCnpjHandlers> logger)
    {
      _vendorRepository = vendorRepository;
      _logger = logger;

    }

    public async Task<CheckVendorExistsByCnpjResponse> Handle(CheckVendorExistsByCnpjRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckVendorExistsByCnpjRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckVendorExistsByCnpjRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var vendor = await _vendorRepository.GetByCnpj(request.Cnpj);

          if (vendor != null)
            return await Task.FromResult(new CheckVendorExistsByCnpjResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckVendorExistsByCnpjResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckVendorExistsByCnpjResponse(request.Id, false, validationResult));
    }
  }
}