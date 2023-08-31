using CloudSuite.Modules.Application.Handlers.Core.Countries.Responses;
using CloudSuite.Modules.Application.Validations.Core.Countries;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Countries
{
  public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, CreateCountryResponse>
  {
    private ICountryRepository _countryRepository;
    private readonly ILogger<CreateCountryHandler> _logger;
    public CreateCountryHandler(ICountryRepository countryRepository, ILogger<CreateCountryHandler> logger)
    {
      _countryRepository = countryRepository;
      _logger = logger;
    }

    public async Task<CreateCountryResponse> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateCountryCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateCountryCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var country = await _countryRepository.GetByName(command.CountryName);

          if (country != null)
            return await Task.FromResult(new CreateCountryResponse(command.Id, "País já cadastrado"));

          await _countryRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateCountryResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateCountryResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateCountryResponse(command.Id, validationResult));
    }
  }
}