using CloudSuite.Modules.Cora.Application.Handlers.Extrato.Requests;
using CloudSuite.Modules.Cora.Application.Handlers.Extrato.Responses;
using CloudSuite.Modules.Cora.Validations.Extrato;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Cora.Application.Handlers.Extrato
{
    public class CheckExtractSearchByDateHandler : IRequestHandler<CheckExtractSearchByDateRequest, CheckExtractSearchByDateResponse>
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CheckExtractSearchByDateHandler> _logger;

        public CheckExtractSearchByDateHandler(ILogger<CheckExtractSearchByDateHandler> logger)
        {
            _httpClient = new HttpClient();
            _logger = logger;

            // Configura a autenticação
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "my-access-token");
        }

        public async Task<CheckExtractSearchByDateResponse> Handle(CheckExtractSearchByDateRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckExtractSearchByDateRequest: {JsonSerializer.Serialize(request)}");

            var validationResult = new CheckExtractSearchByDateRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var response = await _httpClient.GetAsync(
                        $"https://api.stage.cora.com.br/bank-statement/statement/",
                        cancellationToken: cancellationToken
                    );

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        var responseModel = JsonSerializer.Deserialize<CheckExtractSearchByDateResponse>(json);

                        return responseModel;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    throw;
                }
            }

            return await Task.FromResult(new CheckExtractSearchByDateResponse(request.Id, false, validationResult));
        }
    }
}
