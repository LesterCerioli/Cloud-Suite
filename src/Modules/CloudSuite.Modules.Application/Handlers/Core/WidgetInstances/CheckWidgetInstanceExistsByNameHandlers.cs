using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances
{
  public class CheckWidgetInstanceExistsByNameHandlers : IRequestHandler<CheckWidgetInstanceExistsByNameRequest, CheckWidgetInstanceExistsByNameResponse>
  {
    private IWidgetInstanceRepository _widgetInstanceRepository;
    private readonly ILogger<CheckWidgetInstanceExistsByNameHandlers> _logger;
    public CheckWidgetInstanceExistsByNameHandlers(IWidgetInstanceRepository widgetInstanceRepository, ILogger<CheckWidgetInstanceExistsByNameHandlers> logger)
    {
      _widgetInstanceRepository = widgetInstanceRepository;
      _logger = logger;
      
    }

    public async Task<CheckWidgetInstanceExistsByNameResponse> Handle(CheckWidgetInstanceExistsByNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetInstanceExistsByNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetInstanceExistsByNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widgetInstance = await _widgetInstanceRepository.GetByName(request.Name);

          if (widgetInstance != null)
          return await Task.FromResult(new CheckWidgetInstanceExistsByNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetInstanceExistsByNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetInstanceExistsByNameResponse(request.Id, false, validationResult));
    }
  }
} 