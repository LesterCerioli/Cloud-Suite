using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Requests;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances
{
  public class CheckWidgetInstanceExistsByHtmlDataHandlers : IRequestHandler<CheckWidgetInstanceExistsByHtmlDataRequest, CheckWidgetInstanceExistsByHtmlDataResponse>
  {
    private IWidgetInstanceRepository _widgetInstanceRepository;
    private readonly ILogger<CheckWidgetInstanceExistsByHtmlDataHandlers> _logger;
    public CheckWidgetInstanceExistsByHtmlDataHandlers(IWidgetInstanceRepository widgetInstanceRepository, ILogger<CheckWidgetInstanceExistsByHtmlDataHandlers> logger)
    {
      _widgetInstanceRepository = widgetInstanceRepository;
      _logger = logger;
      
    }

    public async Task<CheckWidgetInstanceExistsByHtmlDataResponse> Handle(CheckWidgetInstanceExistsByHtmlDataRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetInstanceExistsByHtmlDataRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetInstanceExistsByHtmlDataRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widgetInstance = await _widgetInstanceRepository.GetByHtmlData(request.HtmlData);

          if (widgetInstance != null)
          return await Task.FromResult(new CheckWidgetInstanceExistsByHtmlDataResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetInstanceExistsByHtmlDataResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetInstanceExistsByHtmlDataResponse(request.Id, false, validationResult));
    }
  }
} 