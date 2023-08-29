using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Responses;
using CloudSuite.Modules.Application.Validations.Core.WidgetZones;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetZones
{
  public class CreateWidgetZoneHandler : IRequestHandler<CreateWidgetZoneCommand, CreateWidgetZoneResponse>
  {
    private IWidgetZoneRepository _widgetZoneRepository;
    private readonly ILogger<CreateWidgetZoneHandler> _logger;
    public CreateWidgetZoneHandler(IWidgetZoneRepository widgetZoneRepository, ILogger<CreateWidgetZoneHandler> logger)
    {
      _widgetZoneRepository = widgetZoneRepository;
      _logger = logger;
    }

    public async Task<CreateWidgetZoneResponse> Handle(CreateWidgetZoneCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateWidgetZoneCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateWidgetZoneCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var widgetZones = await _widgetZoneRepository.GetByName(command.Name);

          if (widgetZones != null)
          return await Task.FromResult(new CreateWidgetZoneResponse(command.Id, "Distrito já cadastrado"));

          await _widgetZoneRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateWidgetZoneResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateWidgetZoneResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateWidgetZoneResponse(command.Id, validationResult));
    }
  }
}