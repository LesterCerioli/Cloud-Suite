using System.Reflection;
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
            return _mapper.Map<RoboEmail>(await _roboEmailRepository.GetByMessageRecipient(messageRecipient));
        }

        public async Task<RoboEmail> GetByReceivedTime(DateTimeOffset receivedTime)
        {
            return _mapper.Map<RoboEmail>(await _roboEmailRepository.GetByReceivedTime(receivedTime));
        }

        public async Task<RoboEmail> GetBySubject(string subject)
        {
            return _mapper.Map<RoboEmail>(await _roboEmailRepository.GetBySubject(subject));
        }

        public Task SendEmailAsync(string emailAddress, string subject, string body, bool isHtml = false)
        {
            throw new NotImplementedException();
        }

        //public async Task SendEmailAsync(string emailAddress, string subject, string body, bool isHtml = false)
        //{

        //}

        // public Task Save(CreateEmailCommand commandCreate)
        //{

        //}
    }


}