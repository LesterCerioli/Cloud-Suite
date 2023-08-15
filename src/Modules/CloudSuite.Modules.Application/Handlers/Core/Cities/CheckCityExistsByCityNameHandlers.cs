using CloudSuite.Modules.Application.Handlers.Core.Cities.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Cities.Requests;
using CloudSuite.Modules.Application.Validations.Core.Cities;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Cities
{
  public class CheckCityExistsByCityNameHandlers : IRequestHandler<CheckCityExistsByCityNameRequest, CheckCityExistsByCityNameResponse>
  {
    private ICityRepository _cityRepository;
    private readonly ILogger<CheckCityExistsByCityNameHandlers> _logger;
    public CheckCityExistsByCityNameHandlers(ICityRepository cityRepository, ILogger<CheckCityExistsByCityNameHandlers> logger)
    {
      _cityRepository = cityRepository;
      _logger = logger;
    }

    public async Task<CheckCityExistsByCityNameResponse> Handle(CheckCityExistsByCityNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckCityExistsByCityNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckCityExistsByCityNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var cities = await _cityRepository.GetByCityName(request.CityName);

          if (cities != null)
          return await Task.FromResult(new CheckCityExistsByCityNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckCityExistsByCityNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckCityExistsByCityNameResponse(request.Id, false, validationResult));
    }
  }
}