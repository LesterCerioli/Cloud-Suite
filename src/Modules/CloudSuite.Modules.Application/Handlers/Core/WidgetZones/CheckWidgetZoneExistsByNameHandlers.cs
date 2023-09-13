using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Responses;
using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetZones;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetZones
{
  public class CheckWidgetZoneExistsByNameHandlers : IRequestHandler<CheckWidgetZoneExistsByNameRequest, CheckWidgetZoneExistsByNameResponse>
  {
    private IWidgetZoneRepository _widgetZoneRepository;
    private readonly ILogger<CheckWidgetZoneExistsByNameHandlers> _logger;
    public CheckWidgetZoneExistsByNameHandlers(IWidgetZoneRepository widgetZoneRepository, ILogger<CheckWidgetZoneExistsByNameHandlers> logger)
    {
      _widgetZoneRepository = widgetZoneRepository;
      _logger = logger;
    }

    public async Task<CheckWidgetZoneExistsByNameResponse> Handle(CheckWidgetZoneExistsByNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetZoneExistsByNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetZoneExistsByNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widgetZone = await _widgetZoneRepository.GetByName(request.Name);

          if (widgetZone != null)
          return await Task.FromResult(new CheckWidgetZoneExistsByNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetZoneExistsByNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetZoneExistsByNameResponse(request.Id, false, validationResult));
    }
  }
} 