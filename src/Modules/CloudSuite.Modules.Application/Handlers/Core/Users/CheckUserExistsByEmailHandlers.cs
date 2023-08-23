using CloudSuite.Modules.Application.Handlers.Core.Users.Responses;
using CloudSuite.Modules.Application.Handlers.Core.Users.Requests;
using CloudSuite.Modules.Application.Validations.Core.Users;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Core.Users
{
  public class CheckUserExistsByEmailHandlers : IRequestHandler<CheckUserExistsByEmailRequest, CheckUserExistsByEmailResponse>
  {
    private IUserRepository _userRepository;
    private readonly ILogger<CheckUserExistsByEmailHandlers> _logger;
    public CheckUserExistsByEmailHandlers(IUserRepository userRepository, ILogger<CheckUserExistsByEmailHandlers> logger)
    {
      _userRepository = userRepository;
      _logger = logger;
    }

    public async Task<CheckUserExistsByEmailResponse> Handle(CheckUserExistsByEmailRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CheckUserExistsByEmailRequest: {JsonSerializer.Serialize(request)}");

      var validationResult = new CheckUserExistsByEmailRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          var state = await _userRepository.GetByEmail(request.Email);

          if (state != null)
          return await Task.FromResult(new CheckUserExistsByEmailResponse(request.Id, true, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new CheckUserExistsByEmailResponse(request.Id, "Não foi possivel processar a solicitação"));
        }
      }
      return await Task.FromResult(new CheckUserExistsByEmailResponse(request.Id, false, validationResult));
    }
  }
} 