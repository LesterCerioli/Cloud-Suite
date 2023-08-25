using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Widgets.Requests;
using CloudSuite.Modules.Application.Validations.Core.Widgets;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets
{
  public class CheckWidgetExistsByCreationDateHandlers : IRequestHandler<CheckWidgetExistsByCreationDateRequest, CheckWidgetExistsByCreationDateResponse>
  {
    private IWidgetRepository _widgetRepository;
    private readonly ILogger<CheckWidgetExistsByCreationDateHandlers> _logger;
    public CheckWidgetExistsByCreationDateHandlers(IWidgetRepository widgetRepository, ILogger<CheckWidgetExistsByCreationDateHandlers> logger)
    {
      _widgetRepository = widgetRepository;
      _logger = logger;
      
    }

    public async Task<CheckWidgetExistsByCreationDateResponse> Handle(CheckWidgetExistsByCreationDateRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckWidgetExistsByCreationDateRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckWidgetExistsByCreationDateRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var widget = await _widgetRepository.GetByCreationDate(request.CreatedOn);

          if (widget != null)
          return await Task.FromResult(new CheckWidgetExistsByCreationDateResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckWidgetExistsByCreationDateResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckWidgetExistsByCreationDateResponse(request.Id, false, validationResult));
    }
  }
  
} 