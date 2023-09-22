using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Services.Contracts.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    internal class TwilioSmsService : ITwilioSmsServices
    {
        private readonly ILogger<ITwilioSmsServices> _logger;
        private readonly IConfiguration _configuration;

        public TwilioSmsService(ILogger<ITwilioSmsServices> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public Task SendSMS(string telefone, string msg)
        {
            string accountSid = _configuration[""]; //parametros que será atribuido no appSetting
            string authToken = _configuration[""]; //quando for adquirido os token no twilio
            string serviceId = _configuration[""];

            try
            {
                TwilioClient.Init(accountSid, authToken);
                var messageOptions = new CreateMessageOptions(new PhoneNumber(telefone));
                messageOptions.MessagingServiceSid = serviceId;
                messageOptions.Body = msg;
                var message = MessageResource.Create(messageOptions);
            }
            catch(Exception ex)
            {
                _logger.LogError("Unable to send SMS", ex);
                throw;
            }

            return Task.CompletedTask;
        }
    }
}
