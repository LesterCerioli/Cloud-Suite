using System.Net;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Reflection;
using System.Text.Json.Serialization;
using AutoMapper;
using CloudSuite.Modules.Application.Handlers.Core.RoboEmails;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using CloudSuite.Modules.Domain.Models.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class RoboEmailService : IRoboEmailService
    {
        private readonly IEmailRepository _roboEmailRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<RoboEmailService> _logger;
        private readonly IConfiguration _configuration;

        public RoboEmailService(
            IEmailRepository roboEmailRepository,
            IMediatorHandler mediator,
            IMapper mapper,
            ILogger<RoboEmailService> logger,
            IConfiguration configuration)
        {
            _roboEmailRepository = roboEmailRepository;
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<RoboEmail> GetByMessageRecipient(string messageRecipient)
        {
            _logger.LogInformation($"Getting RoboEmail by message recipient: {messageRecipient}");
            return _mapper.Map<RoboEmail>(await _roboEmailRepository.GetByMessageRecipient(messageRecipient));
        }

        public async Task<RoboEmail> GetByReceivedTime(DateTimeOffset receivedTime)
        {
            _logger.LogInformation($"Getting RoboEmail by received time: {receivedTime}");
            return _mapper.Map<RoboEmail>(await _roboEmailRepository.GetByReceivedTime(receivedTime));
        }

        public async Task<RoboEmail> GetBySubject(string subject)
        {
            _logger.LogInformation($"Getting RoboEmail by subject: {subject}");
            return _mapper.Map<RoboEmail>(await _roboEmailRepository.GetBySubject(subject));
        }

        public async Task SendEmailAsync(string emailAddress, string subject, string body, bool isHtml = false)
        {
            _logger.LogInformation($"Sending email to: {emailAddress}, Subject: {subject}");

            //dynamic json = JsonConverter.DeserializeObject();

            var smtpClient = new SmtpClient
            {
                Host = "",    
                Port = 587,             
                Credentials = new NetworkCredential("username", "password"), 
                EnableSsl = true               
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("sender@example.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = isHtml
            };

            mailMessage.To.Add(emailAddress);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                _logger.LogInformation("Email sent successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email.");
                throw; 
            }
            
        }

        public async Task Save(CreateRoboEmailCommand commandCreate)
        {
            _logger.LogInformation($"Saving RoboEmail with CreateRoboEmailCommand: {commandCreate}");
            var roboEmail = _mapper.Map<RoboEmail>(commandCreate);

            //return await _roboEmailRepository(roboEmail);
        }
    }


}