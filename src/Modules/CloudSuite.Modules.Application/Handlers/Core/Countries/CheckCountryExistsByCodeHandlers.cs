using CloudSuite.Modules.Application.Handlers.Core.Countries.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Countries.Requests;
using CloudSuite.Modules.Application.Validations.Core.Countries;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Countries
{
  public class CheckCountryExistsByCodeHandlers : IRequestHandler<CheckCountryExistsByCodeRequest, CheckCountryExistsByCodeResponse>
  {
    private ICountryRepository _countryRepository;
    private readonly ILogger<CheckCountryExistsByCodeHandlers> _logger;
    public CheckCountryExistsByCodeHandlers(ICountryRepository countryRepository, ILogger<CheckCountryExistsByCodeHandlers> logger)
    {
      _countryRepository = countryRepository;
      _logger = logger;
    }

    public async Task<CheckCountryExistsByCodeResponse> Handle(CheckCountryExistsByCodeRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckCountryExistsByCodeRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckCountryExistsByCodeRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var countries = await _countryRepository.GetByCode(request.Code3);

          if (countries != null)
          return await Task.FromResult(new CheckCountryExistsByCodeResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckCountryExistsByCodeResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckCountryExistsByCodeResponse(request.Id, false, validationResult));
    }
  }
}