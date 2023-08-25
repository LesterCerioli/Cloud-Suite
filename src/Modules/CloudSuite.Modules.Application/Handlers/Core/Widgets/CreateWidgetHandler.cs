using CloudSuite.Modules.Application.Handlers.Core.Widgets.Responses;
using CloudSuite.Modules.Application.Validations.Core.Widgets;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Widgets
{
  public class CreateWidgetHandler : IRequestHandler<CreateWidgetCommand, CreateWidgetResponse>
  {
    private IWidgetRepository _widgetRepository;
    private readonly ILogger<CreateWidgetHandler> _logger;
    public CreateWidgetHandler(IWidgetRepository widgetRepository, ILogger<CreateWidgetHandler> logger)
    {
      _widgetRepository = widgetRepository;
      _logger = logger;
    }

    public async Task<CreateWidgetResponse> Handle(CreateWidgetCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateWidgetCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateWidgetCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var widgets = await _widgetRepository.GetByName(command.Name);

          if (widgets != null)
            return await Task.FromResult(new CreateWidgetResponse(command.Id, "Distrito já cadastrado"));

          await _widgetRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateWidgetResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateWidgetResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateWidgetResponse(command.Id, validationResult));
    }
  }
}