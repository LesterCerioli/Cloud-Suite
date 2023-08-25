using CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses;
using CloudSuite.Modules.Application.Validations.Core.Vendores;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Vendores
{
  public class CreateVendorHandler : IRequestHandler<CreateVendorCommand, CreateVendorResponse>
  {
    private IVendorRepository _vendorRepository;
    private readonly ILogger<CreateVendorHandler> _logger;
    public CreateVendorHandler(IVendorRepository vendorRepository, ILogger<CreateVendorHandler> logger)
    {
      _vendorRepository = vendorRepository;
      _logger = logger;
    }

    public async Task<CreateVendorResponse> Handle(CreateVendorCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateVendorCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateVendorCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var vendores = await _vendorRepository.GetByCnpj(command.Cnpj);

          if (vendores != null)
            return await Task.FromResult(new CreateVendorResponse(command.Id, "Distrito já cadastrado"));

          await _vendorRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateVendorResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateVendorResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateVendorResponse(command.Id, validationResult));
    }
  }
}