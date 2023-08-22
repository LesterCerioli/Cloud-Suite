using CloudSuite.Modules.Application.Handlers.Core.States.Responses;
using CloudSuite.Modules.Application.Validations.Core.States;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.States
{
  public class CreateStateHandler : IRequestHandler<CreateStateCommand, CreateStateResponse>
  {
    private IStateRepository _stateRepository;
    private readonly ILogger<CreateStateHandler> _logger;
    public CreateStateHandler(IStateRepository stateRepository, ILogger<CreateStateHandler> logger)
    {
      _stateRepository = stateRepository;
      _logger = logger;
    }

    public async Task<CreateStateResponse> Handle(CreateStateCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateStateCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateStateCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var states = await _stateRepository.GetByName(command.StateName);

          if (states != null)
          return await Task.FromResult(new CreateStateResponse(command.Id, "Distrito já cadastrado"));

          await _stateRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateStateResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateStateResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateStateResponse(command.Id, validationResult));
    }
  }
}