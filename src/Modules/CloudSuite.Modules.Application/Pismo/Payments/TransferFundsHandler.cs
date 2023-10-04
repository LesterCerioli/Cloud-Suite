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
        private readonly ILogger<TransferFundsHandler> _logger;

        public TransferFundsHandler(ILogger<TransferFundsHandler> logger)
        {
            _logger = logger;
        }

        public async Task<TransferFundsResponse> Handle(TransferFundsRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"TransferFundsRequest: {JsonConvert.SerializeObject(request)}");

            var validationResult = request; //tem que criar o metodo de validar a request ainda

            if (validationResult != null)
            {
                try
                {
                    using var client = new HttpClient();

                    client.DefaultRequestHeaders.Add("x-tenant", tenantId);
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

                    var requestContent = new StringContent(request.ToJson(), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://api-sandbox.pismolabs.io/payments/v1/payments", requestContent);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<TransferFundsResponse>(responseContent);
                    }
                    else
                    {
                        _logger.LogError($"Failed to transfer funds: {response.StatusCode}");

                        return new TransferFundsResponse("Failed to transfer funds");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to transfer funds: {ex.Message}");

                    return new TransferFundsResponse("Failed to transfer funds");
                }
            }
            else
            {
                return new TransferFundsResponse("Invalid request");
            }
        }
    }
}