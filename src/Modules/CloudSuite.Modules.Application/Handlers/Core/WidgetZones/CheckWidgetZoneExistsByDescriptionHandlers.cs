using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Responses;
using CloudSuite.Modules.Application.Handlers.Core.WidgetZones.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetZones;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetZones
{
  public class CheckWidgetZoneExistsByDescriptionHandlers : IRequestHandler<CheckWidgetZoneExistsByDescriptionRequest, CheckWidgetZoneExistsByDescriptionResponse>
  {
    private IWidgetZoneRepository _widgetZoneRepository;
    private readonly ILogger<CheckWidgetZoneExistsByDescriptionHandlers> _logger;
    public CheckWidgetZoneExistsByDescriptionHandlers(IWidgetZoneRepository widgetZoneRepository, ILogger<CheckWidgetZoneExistsByDescriptionHandlers> logger)
    {
      _widgetZoneRepository = widgetZoneRepository;
      _logger = logger;
    }

    public async Task<CheckWidgetZoneExistsByDescriptionResponse> Handle(CheckWidgetZoneExistsByDescriptionRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetZoneExistsByDescriptionRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetZoneExistsByDescriptionRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widgetZone = await _widgetZoneRepository.GetByDescription(request.Description);

          if (widgetZone != null)
          return await Task.FromResult(new CheckWidgetZoneExistsByDescriptionResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetZoneExistsByDescriptionResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetZoneExistsByDescriptionResponse(request.Id, false, validationResult));
    }
  }
} 