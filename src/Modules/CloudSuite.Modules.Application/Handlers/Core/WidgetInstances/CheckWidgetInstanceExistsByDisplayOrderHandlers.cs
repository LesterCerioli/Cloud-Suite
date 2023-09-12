using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances
{
  public class CheckWidgetInstanceExistsByDisplayOrderHandlers : IRequestHandler<CheckWidgetInstanceExistsByDisplayOrderRequest, CheckWidgetInstanceExistsByDisplayOrderResponse>
  {
    private IWidgetInstanceRepository _widgetInstanceRepository;
    private readonly ILogger<CheckWidgetInstanceExistsByDisplayOrderHandlers> _logger;
    public CheckWidgetInstanceExistsByDisplayOrderHandlers(IWidgetInstanceRepository widgetInstanceRepository, ILogger<CheckWidgetInstanceExistsByDisplayOrderHandlers> logger)
    {
      _widgetInstanceRepository = widgetInstanceRepository;
      _logger = logger;
      
    }

    public async Task<CheckWidgetInstanceExistsByDisplayOrderResponse> Handle(CheckWidgetInstanceExistsByDisplayOrderRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetInstanceExistsByDisplayOrderRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetInstanceExistsByDisplayOrderRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widgetInstance = await _widgetInstanceRepository.GetByDisplayOrder(request.DisplayOrder);

          if (widgetInstance != null)
          return await Task.FromResult(new CheckWidgetInstanceExistsByDisplayOrderResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetInstanceExistsByDisplayOrderResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetInstanceExistsByDisplayOrderResponse(request.Id, false, validationResult));
    }
  }
} 