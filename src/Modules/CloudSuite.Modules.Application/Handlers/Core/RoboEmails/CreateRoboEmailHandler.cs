using CloudSuite.Modules.Application.Handlers.Core.RoboEmails.Responses;
using CloudSuite.Modules.Application.Validations.Core.RoboEmail;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;


namespace CloudSuite.Modules.Application.Handlers.Core.RoboEmails
{
  public class CreateRoboEmailHandler : IRequestHandler<CreateRoboEmailCommand, CreateRoboEmailResponse>
  {

    private readonly IRoboEmailRepository _roboEmailRepository;
    private readonly ILogger<CreateRoboEmailHandler> _logger;
    public CreateRoboEmailHandler(IRoboEmailRepository roboEmailRepository, ILogger<CreateRoboEmailHandler> logger)
    {
      _roboEmailRepository = roboEmailRepository;
      _logger = logger;
    }

    public async Task<CreateRoboEmailResponse> Handle(CreateRoboEmailCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateRoboEmailCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateRoboEmailCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var emails = await _roboEmailRepository.GetBySubject(command.Subject);

          if (emails != null)
            return await Task.FromResult(new CreateRoboEmailResponse(command.Id, "Distrito já cadastrado"));

          await _roboEmailRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateRoboEmailResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateRoboEmailResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateRoboEmailResponse(command.Id, validationResult));
    }
  }
}