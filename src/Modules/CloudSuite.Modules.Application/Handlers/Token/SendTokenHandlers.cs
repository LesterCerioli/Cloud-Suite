using CloudSuite.Modules.Application.Services.Contracts.Token;
using CloudSuite.Modules.Application.Handlers.Token.Responses;
using CloudSuite.Modules.Application.Handlers.Token.Requests;
using CloudSuite.Modules.Application.Validations.Token;
using CloudSuite.Modules.Domain.Contracts.Token;
using CloudSuite.Modules.Domain.Models.Token;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Token
{
  public class SendTokenHandlers : IRequestHandler<SendTokenRequest, SendTokenReponse>
  {
    private IRequestTokenRepository _requestTokenRepository;

    private ITwilioSmsServices _twilioService;

    private readonly ILogger<SendTokenHandlers> _logger;

    public SendTokenHandlers(IRequestTokenRepository requestTokenRepository, ITwilioSmsServices twilioService, ILogger<SendTokenHandlers> logger)
    {
      _requestTokenRepository = requestTokenRepository;
      _twilioService = twilioService;
      _logger = logger;
    }

    public async Task<SendTokenReponse> Handle(SendTokenRequest request, CancellationToken cancellationToken)
    {
      _logger.LogInformation($"SendTokenRequest: {JsonSerializer.Serialize(request)}");

      // Request valido (telefone)
      var validationResult = new SendTokenRequestValidation().Validate(request);

      if (validationResult.IsValid)
      {
        try
        {
          // Excluir token anterior existente
          await _requestTokenRepository.DeleteByPhone(request.Telephone);

          // Cria novo token
          RequestToken requestToken = new(request.Id, request.FullName, request.Telephone, DateTime.Now);

          // Envia sms
          await _twilioService.SendSMS(
              "+" + request.Telephone,
              "Lucas Technology Services." + request.FullName + " seu token é: " + requestToken.Token);

          // Persiste na base
          await _requestTokenRepository.Add(requestToken);

          // Retorna RequestId, 
          return await Task.FromResult(new SendTokenReponse(request.Id, validationResult, true));
        }
        catch (Exception ex)
        {
          _logger.LogCritical(ex.Message);
          return await Task.FromResult(new SendTokenReponse(request.Id, "Não foi possivel Processar solicitação.", false));
        }
      }
      // Retorna Erro validacao, 
      return await Task.FromResult(new SendTokenReponse(request.Id, validationResult, false));
    }
  }
}
