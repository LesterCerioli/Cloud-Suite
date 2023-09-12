using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances
{
  public class CheckWidgetInstanceExistsByWidgetIdHandlers : IRequestHandler<CheckWidgetInstanceExistsByWidgetIdRequest, CheckWidgetInstanceExistsByWidgetIdResponse>
  {
    private IWidgetInstanceRepository _widgetInstanceRepository;
    private readonly ILogger<CheckWidgetInstanceExistsByWidgetIdHandlers> _logger;
    public CheckWidgetInstanceExistsByWidgetIdHandlers(IWidgetInstanceRepository widgetInstanceRepository, ILogger<CheckWidgetInstanceExistsByWidgetIdHandlers> logger)
    {
      _widgetInstanceRepository = widgetInstanceRepository;
      _logger = logger;
      
    }

    public async Task<CheckWidgetInstanceExistsByWidgetIdResponse> Handle(CheckWidgetInstanceExistsByWidgetIdRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetInstanceExistsByWidgetIdRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetInstanceExistsByWidgetIdRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widgetInstance = await _widgetInstanceRepository.GetByWidgetId(request.WidgetId);

          if (widgetInstance != null)
          return await Task.FromResult(new CheckWidgetInstanceExistsByWidgetIdResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetInstanceExistsByWidgetIdResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetInstanceExistsByWidgetIdResponse(request.Id, false, validationResult));
    }
  }
} 