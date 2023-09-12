using CloudSuite.Modules.Application.Handlers.Core.Users.Responses;
using CloudSuite.Modules.Application.Validations.Core.Users;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Users
{
  public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
  {
    private IUserRepository _userRepository;
    private readonly ILogger<CreateUserHandler> _logger;
    public CreateUserHandler(IUserRepository userRepository, ILogger<CreateUserHandler> logger)
    {
      _userRepository = userRepository;
      _logger = logger;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateUserCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateUserCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var users = await _userRepository.GetByCpf(command.Cpf);

          if (users != null)
          return await Task.FromResult(new CreateUserResponse(command.Id, "Distrito já cadastrado"));

          await _userRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateUserResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateUserResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }
      return await Task.FromResult(new CreateUserResponse(command.Id, validationResult));
    }
  }
}