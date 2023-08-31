using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using CloudSuite.Modules.Application.Validations.Core.Widgets;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets
{
  public class CheckWidgetExistsByNameHandlers : IRequestHandler<CheckWidgetExistsByNameRequest, CheckWidgetExistsByNameResponse>
  {
    private IWidgetRepository _widgetRepository;
    private readonly ILogger<CheckWidgetExistsByNameHandlers> _logger;
    public CheckWidgetExistsByNameHandlers(IWidgetRepository widgetRepository, ILogger<CheckWidgetExistsByNameHandlers> logger)
    {
      _widgetRepository = widgetRepository;
      _logger = logger;

    }

    public async Task<CheckWidgetExistsByNameResponse> Handle(CheckWidgetExistsByNameRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetExistsByNameRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetExistsByNameRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widget = await _widgetRepository.GetByName(request.Name);

          if (widget != null)
            return await Task.FromResult(new CheckWidgetExistsByNameResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetExistsByNameResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetExistsByNameResponse(request.Id, false, validationResult));
    }
  }
}