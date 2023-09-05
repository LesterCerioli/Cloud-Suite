using CloudSuite.Modules.Application.Handlers.Token.Responses;
using CloudSuite.Modules.Application.Validations.Token;
using CloudSuite.Modules.Domain.Contracts.Token;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Token
{
  public class CreateTokenHandler : IRequestHandler<CreateTokenCommand, CreateTokenResponse>
  {
    private IRequestTokenRepository _requestTokenRepository;
    private readonly ILogger<CreateTokenHandler> _logger;
    public CreateTokenHandler(IRequestTokenRepository requestTokenRepository, ILogger<CreateTokenHandler> logger)
    {
      _requestTokenRepository = requestTokenRepository;
      _logger = logger;
    }

    public async Task<CreateTokenResponse> Handle(CreateTokenCommand command, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"CreateTokenCommand: {JsonSerializer.Serialize(command)}");

      var validationResult = new CreateTokenCommandValidation().Validate(command);

      if (validationResult.IsValid)
      {
        try
        {
          var token = await _requestTokenRepository.GetByRequestId(command.Id);

          if (token != null)
            return await Task.FromResult(new CreateTokenResponse(command.Id, "Token já cadastrado"));

          await _requestTokenRepository.Add(command.GetEntity());

          return await Task.FromResult(new CreateTokenResponse(command.Id, validationResult));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);

          return await Task.FromResult(new CreateTokenResponse(command.Id, "Não foi possivel processar a solicitação."));
        }
      }

      return await Task.FromResult(new CreateTokenResponse(command.Id, validationResult));
    }
  }
}