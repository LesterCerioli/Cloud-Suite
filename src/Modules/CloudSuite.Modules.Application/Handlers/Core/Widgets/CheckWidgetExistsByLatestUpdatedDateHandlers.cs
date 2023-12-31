using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using CloudSuite.Modules.Application.Validations.Core.Widgets;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets
{
  public class CheckWidgetExistsByLatestUpdatedDateHandlers : IRequestHandler<CheckWidgetExistsByLatestUpdatedDateRequest, CheckWidgetExistsByLatestUpdatedDateResponse>
  {
    private IWidgetRepository _widgetRepository;
    private readonly ILogger<CheckWidgetExistsByLatestUpdatedDateHandlers> _logger;
    public CheckWidgetExistsByLatestUpdatedDateHandlers(IWidgetRepository widgetRepository, ILogger<CheckWidgetExistsByLatestUpdatedDateHandlers> logger)
    {
      _widgetRepository = widgetRepository;
      _logger = logger;
    }

    public async Task<CheckWidgetExistsByLatestUpdatedDateResponse> Handle(CheckWidgetExistsByLatestUpdatedDateRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetExistsByLatestUpdatedDateRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetExistsByLatestUpdatedDateRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widget = await _widgetRepository.GetByLatestUpdatedDate(request.CreateUrl);

          if (widget != null)
            return await Task.FromResult(new CheckWidgetExistsByLatestUpdatedDateResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetExistsByLatestUpdatedDateResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetExistsByLatestUpdatedDateResponse(request.Id, false, validationResult));
    }
  }
}