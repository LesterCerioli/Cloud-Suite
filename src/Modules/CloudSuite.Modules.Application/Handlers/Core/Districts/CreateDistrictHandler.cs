using CloudSuite.Modules.Application.Handlers.Core.Districts.Responses;
using CloudSuite.Modules.Application.Validations.Core.District;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Districts
{
  public class CreateDistrictHandler : IRequestHandler<CreateDistrictCommand, CreateDistrictResponse>
  {
    private IDistrictRepository _districtRepository;
    private readonly ILogger<CreateDistrictHandler> _logger;
    public CreateDistrictHandler(IDistrictRepository districtRepository, ILogger<CreateDistrictHandler> logger)
    {
      _districtRepository = districtRepository;
      _logger = logger;
    }

    public async Task<CreateDistrictResponse> Handle(CreateDistrictCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateDistrictCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateDistrictCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var districts = await _districtRepository.GetByName(command.Name);

          if (districts != null)
            return await Task.FromResult(new CreateDistrictResponse(command.Id, "Distrito já cadastrado"));

          await _districtRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateDistrictResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateDistrictResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateDistrictResponse(command.Id, validationResult));
    }
  }
}