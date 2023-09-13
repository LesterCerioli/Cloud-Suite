using CloudSuite.Modules.Application.Handlers.Core.WidgetInstances.Responses;
using CloudSuite.Modules.Application.Validations.Core.WidgetInstances;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.WidgetInstances
{
  public class CreateWidgetInstanceHandler : IRequestHandler<CreateWidgetInstanceCommand, CreateWidgetInstanceResponse>
  {
    private IWidgetInstanceRepository _widgetInstanceRepository;
    private readonly ILogger<CreateWidgetInstanceHandler> _logger;
    public CreateWidgetInstanceHandler(IWidgetInstanceRepository widgetInstanceRepository, ILogger<CreateWidgetInstanceHandler> logger)
    {
      _widgetInstanceRepository = widgetInstanceRepository;
      _logger = logger;
    }

    public async Task<CreateWidgetInstanceResponse> Handle(CreateWidgetInstanceCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateWidgetInstanceCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateWidgetInstanceCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var WidgetInstance = await _widgetInstanceRepository.GetByName(command.Name);

          if (WidgetInstance != null)
            return await Task.FromResult(new CreateWidgetInstanceResponse(command.Id, "Distrito já cadastrado"));

          await _widgetInstanceRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateWidgetInstanceResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateWidgetInstanceResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateWidgetInstanceResponse(command.Id, validationResult));
    }
  }
}