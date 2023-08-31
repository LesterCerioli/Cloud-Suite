using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using CloudSuite.Modules.Application.Validations.Core.Widgets;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets
{
  public class CheckWidgetExistsByEditUrlHandlers : IRequestHandler<CheckWidgetExistsByEditUrlRequest, CheckWidgetExistsByEditUrlResponse>
  {
    private IWidgetRepository _widgetRepository;
    private readonly ILogger<CheckWidgetExistsByEditUrlHandlers> _logger;
    public CheckWidgetExistsByEditUrlHandlers(IWidgetRepository widgetRepository, ILogger<CheckWidgetExistsByEditUrlHandlers> logger)
    {
      _widgetRepository = widgetRepository;
      _logger = logger;
      
    }

    public async Task<CheckWidgetExistsByEditUrlResponse> Handle(CheckWidgetExistsByEditUrlRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetExistsByEditUrlRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetExistsByEditUrlRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widget = await _widgetRepository.GetByEditUrl(request.EditUrl);

          if (widget != null)
          return await Task.FromResult(new CheckWidgetExistsByEditUrlResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetExistsByEditUrlResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetExistsByEditUrlResponse(request.Id, false, validationResult));
    }
  }
} 