using CloudSuite.Modules.Application.Handlers.Core.Countries.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Countries.Requests;
using CloudSuite.Modules.Application.Validations.Core.Countries;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Countries
{
  public class CheckCountryExistsByNameHandlers : IRequestHandler<CheckCountryExistsByNameRequest, CheckCountryExistsByNameResponse>
  {
    private ICountryRepository _countryRepository;
    private readonly ILogger<CheckCountryExistsByNameHandlers> _logger;
    public CheckCountryExistsByNameHandlers(ICountryRepository countryRepository, ILogger<CheckCountryExistsByNameHandlers> logger)
    {
      _countryRepository = countryRepository;
      _logger = logger;
    }

    public async Task<CheckCountryExistsByNameResponse> Handle(CheckCountryExistsByNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckCountryExistsByNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckCountryExistsByNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var countries = await _countryRepository.GetByCode(request.CountryName);

          if (countries != null)
            return await Task.FromResult(new CheckCountryExistsByNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckCountryExistsByNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckCountryExistsByNameResponse(request.Id, false, validationResult));
    }
  }
}