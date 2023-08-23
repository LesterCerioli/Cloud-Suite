using CloudSuite.Modules.Application.Handlers.Core.Users.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Users.Requests;
using CloudSuite.Modules.Application.Validations.Core.Users;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Users
{
  public class CheckUserExistsByCpfHandlers : IRequestHandler<CheckUserExistsByCpfRequest, CheckUserExistsByCpfResponse>
  {
    private IUserRepository _userRepository;
    private readonly ILogger<CheckUserExistsByCpfHandlers> _logger;
    public CheckUserExistsByCpfHandlers(IUserRepository userRepository, ILogger<CheckUserExistsByCpfHandlers> logger)
    {
      _userRepository = userRepository;
      _logger = logger;
      
    }

    public async Task<CheckUserExistsByCpfResponse> Handle(CheckUserExistsByCpfRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckUserExistsByCpfRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckUserExistsByCpfRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var state = await _userRepository.GetByCpf(request.Cpf);

          if (state != null)
          return await Task.FromResult(new CheckUserExistsByCpfResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckUserExistsByCpfResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckUserExistsByCpfResponse(request.Id, false, validationResult));
    }
  }
} 