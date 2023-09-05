using CloudSuite.Modules.Application.Services.Contracts.Token;
using CloudSuite.Modules.Application.Handlers.Token.Responses;
using CloudSuite.Modules.Application.Handlers.Token.Requests;
using CloudSuite.Modules.Domain.Contracts.Token;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Web.Http;
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
            request.PhoneNumber = request.PhoneNumber.Trim();

            // Request valido (telefone)
            var validationResult = new SendTokenRequestValidation().Validate(request);
            
            if (validationResult.IsValid)
            {
                try
                {
                    // 2 Excluir anteriores
                    await _repositorioToken.ExcluirPorTelefone(request.PhoneNumber.Trim());

                    // 3 Cria novo token
                    RequestToken requestToken = new(request.Id, request.Name, request.PhoneRegion, request.PhoneNumber, DateTime.Now);

                    // 4 Envia sms
                    await _twilioService.SendSMS(
                        "+" + request.PhoneRegion + request.PhoneNumber,
                        "Cuidados pela vida. " + request.Name + " seu token é: " + requestToken.Token);
                    // 5 Persiste na base

                    await _repositorioToken.Add(requestToken);

                    // 6 Retorna RequestId, 
                    return await Task.FromResult(new SendTokenReponse(request.Id, validationResult, true));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new SendTokenReponse(request.Id, "Não foi possivel Processar solicitação.", false));
                }
            }
            // 7 Retorna Erro validacao, 
            return await Task.FromResult(new SendTokenReponse(request.Id,  validationResult, false));
        }
    }
}
