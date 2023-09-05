using CloudSuite.Modules.Application.Handlers.Token.Responses;
using CloudSuite.Modules.Application.Handlers.Token.Requests;
using CloudSuite.Modules.Application.Validations.Token;
using CloudSuite.Modules.Domain.Contracts.Token;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Web.Http;
using MediatR;

namespace CloudSuite.Modules.Application.Handlers.Token
{
    [AllowAnonymous]
    public  class ValidateTokenHandler : IRequestHandler<ValidateTokenRequest, ValidateTokenResponse>
    {
        private IRequestTokenRepository _requestTokenRepository;
        private readonly ILogger<ValidateTokenHandler> _logger;

        private int maxValidMinutes = 30;

        public ValidateTokenHandler(IRequestTokenRepository requestTokenRepository, ILogger<ValidateTokenHandler> logger)
        {
            _requestTokenRepository = requestTokenRepository;
            _logger = logger;
        }

        public async Task<ValidateTokenResponse> Handle(ValidateTokenRequest request, CancellationToken cancellationToken)
        {
            request.Token = request.Token.Trim();

            _logger.LogInformation($"ValidateTokenRequest: {JsonSerializer.Serialize(request)}");

            // Valida Request
            var validationResult = new ValidateTokenRequestValidation().Validate(request);
            try
            {
                if (validationResult.IsValid)
                {
                    // 2 valida na base de dados se Request Id existe

                    var originalRequest = await _requestTokenRepository.GetByRequestId(Guid.Parse(request.RequestId));

                    if (originalRequest == null)
                    {
                        return await Task.FromResult(new ValidateTokenResponse(request.Id, false, "Token inválido"));
                    }
                    // 3 Se existir na base, valida o tempo
                    bool TempoInValido = originalRequest.Created.AddMinutes(maxMinutosValidos) < DateTime.Now;
                    // 4 Valida token
                    bool TokenDiferente = (originalRequest.Token != request.Token);

                    if (TempoInValido || TokenDiferente || originalRequest.Validated.HasValue)
                    {
                        return await Task.FromResult(new ValidateTokenResponse(request.Id, false, "Token inválido"));
                    }

                    // 5 Persistir na base que aquele RequestToken foi validado
                    originalRequest.Validated = DateTime.Now;
                    await _requestTokenRepository.Update(originalRequest);

                    return await Task.FromResult(new ValidateTokenResponse(request.Id, true));

                }
                // 6 Retorna Erro Validacao
                return await Task.FromResult(new ValidateTokenResponse(request.Id, false, validationResult));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return await Task.FromResult(new ValidateTokenResponse(request.Id, false, "Não foi possivel Processar solicitação."));
            }
            
        }
    }
}
