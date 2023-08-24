using CloudSuite.Modules.Application.Handlers.Core.Cities.Responses;
using CloudSuite.Modules.Application.Validations.Core.Cities;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Cities
{
  public class CreateCityHandler : IRequestHandler<CreateCityCommand, CreateCityResponse>
  {
    private ICityRepository _cityRepository;
    private readonly ILogger<CreateCityHandler> _logger;
    public CreateCityHandler(ICityRepository cityRepository, ILogger<CreateCityHandler> logger)
    {
      _cityRepository = cityRepository;
      _logger = logger;
    }
    public async Task<CreateCityResponse> Handle(CreateCityCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateCityCommand: {JsonSerializer.Serialize(command)}");
      
      var validationResult = new CreateCityCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var cities = await _cityRepository.GetByCityName(command.CityName);

          if (cities != null)
          return await Task.FromResult(new CreateCityResponse(command.Id, "Cidade já cadastrada."));

          await _cityRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateCityResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateCityResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }

      return await Task.FromResult(new CreateCityResponse(command.Id, validationResult));
    }
  }
}