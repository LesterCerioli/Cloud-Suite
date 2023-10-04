using CloudSuite.Modules.Application.Handlers.Pismo.Request;
using CloudSuite.Modules.Application.Handlers.Pismo.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CloudSuite.Modules.Application.Handlers.Pismo
{
    public class TransferFundsHandler : IRequestHandler<TransferFundsRequest, TransferFundsResponse>
    {
        private readonly string apiKey = "YOUR_ACCESS_TOKEN";
        private readonly string tenantId = "YOUR_TENANT_ID";
        private readonly object idFromAccount, idToAccount;
        private readonly ILogger<TransferFundsHandler> _logger;

        public TransferFundsHandler(ILogger<TransferFundsHandler> logger)
        {
            _logger = logger;
        }

        public async Task<TransferFundsResponse> Handle(TransferFundsRequest request, CancellationToken cancellationToken)
        {
            string message = $"TransferFundsRequest: {JsonConvert.SerializeObject(request, typeof(TransferFundsRequest)}";
            _logger.LogInformation(message);

            var validationResult = new TransferFundsRequest(idFromAccount, idToAccount).Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    // Criando um cliente HTTP
                    var client = new HttpClient();

                    // Adicionando as credenciais da API aos headers
                    client.DefaultRequestHeaders.Add("x-tenant", tenantId);
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

                    // Enviando a requisição
                    var response = await client.PostAsync("https://api-sandbox.pismolabs.io/payments/v1/payments", new StringContent(request.ToJson(), Encoding.UTF8));

                    // Verificando o status code
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // Request enviado com sucesso
                        return await Task.FromResult(JsonConvert.DeserializeObject<TransferFundsResponse>(response.Content.ReadAsStringAsync().Result));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new TransferFundsResponse("Não foi possivel processar a solicitação"));
                }
                
            }
        }
    } 
}
            