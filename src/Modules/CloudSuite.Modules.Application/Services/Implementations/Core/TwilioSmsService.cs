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
    public class TwilioSmsService : ITwilioSmsServices
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
            string accountSid = _configuration["Twilio:AccountSid"]; 
            string authToken = _configuration["Twilio:AuthToken"];
            

            try
            {
                TwilioClient.Init(accountSid, authToken);
                var messageOptions = new CreateMessageOptions(new PhoneNumber(telefone));
                messageOptions.MessagingServiceSid = accountSid;
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
