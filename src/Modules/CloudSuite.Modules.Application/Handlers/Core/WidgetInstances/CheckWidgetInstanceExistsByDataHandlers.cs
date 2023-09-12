using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances
{
  public class CheckWidgetInstanceExistsByDataHandlers : IRequestHandler<CheckWidgetInstanceExistsByDataRequest, CheckWidgetInstanceExistsByDataResponse>
  {
    private IWidgetInstanceRepository _widgetInstanceRepository;
    private readonly ILogger<CheckWidgetInstanceExistsByDataHandlers> _logger;
    public CheckWidgetInstanceExistsByDataHandlers(IWidgetInstanceRepository widgetInstanceRepository, ILogger<CheckWidgetInstanceExistsByDataHandlers> logger)
    {
      _widgetInstanceRepository = widgetInstanceRepository;
      _logger = logger;
      
    }

    public async Task<CheckWidgetInstanceExistsByDataResponse> Handle(CheckWidgetInstanceExistsByDataRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetInstanceExistsByDataRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetInstanceExistsByDataRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widgetInstance = await _widgetInstanceRepository.GetByData(request.Data);

          if (widgetInstance != null)
          return await Task.FromResult(new CheckWidgetInstanceExistsByDataResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetInstanceExistsByDataResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetInstanceExistsByDataResponse(request.Id, false, validationResult));
    }
  }
} 