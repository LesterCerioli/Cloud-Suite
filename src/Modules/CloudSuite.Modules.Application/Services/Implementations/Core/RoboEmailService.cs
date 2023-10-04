using CloudSuite.Modules.Application.Handlers.Core.RoboEmails;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using System.Diagnostics.Contracts;
using SendGrid.Helpers.Mail;
using NetDevPack.Mediator;
using AutoMapper;
using SendGrid;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
  public class RoboEmailService : IRoboEmailService
  {
    private readonly IRoboEmailRepository _roboEmailRepository;

    private readonly IMapper _mapper;

    private readonly IMediatorHandler _mediator;

    private readonly string _apiKey;

    private readonly string _fromEmail;

    private readonly string _fromName;

    public RoboEmailService(IRoboEmailRepository roboEmailRepository, IMapper mapper, IMediatorHandler mediator, IConfiguration configuration)
    {
      _roboEmailRepository = roboEmailRepository;
      _mapper = mapper;
      _mediator = mediator;
      _apiKey = configuration.GetSection("SendGrid:ApiKey").Value;
      _fromEmail = configuration.GetSection("SendGrid:FromEmail").Value;
      _fromName = configuration.GetSection("SendGrid:FromName").Value;

      Contract.Requires(!string.IsNullOrWhiteSpace(_apiKey));
      Contract.Requires(!string.IsNullOrWhiteSpace(_fromEmail));
      Contract.Requires(!string.IsNullOrWhiteSpace(_fromName));
    }

    public async Task<RoboEmailViewModel> GetBySubject(string subject)
    {
      return _mapper.Map<RoboEmailViewModel>(await _roboEmailRepository.GetBySubject(subject));
    }

    public async Task Save(CreateRoboEmailCommand commandCreate)
    {
      await _roboEmailRepository.Add(commandCreate.GetEntity());
    }

    public async Task SendEmailAsync(string emailAddress, string subject, string body, bool isHtml = false)
    {
      Contract.Requires(!string.IsNullOrWhiteSpace(emailAddress));
      Contract.Requires(!string.IsNullOrWhiteSpace(subject));
      Contract.Requires(!string.IsNullOrWhiteSpace(body));

      var sendGridMessage = new SendGridMessage();

      sendGridMessage.From = new EmailAddress(_fromEmail, _fromName);
      sendGridMessage.AddTo(new EmailAddress(emailAddress));
      sendGridMessage.Subject = subject;
      sendGridMessage.HtmlContent = isHtml ? body : "";
      sendGridMessage.PlainTextContent = isHtml ? Regex.Replace(body, "<[^>]*>", "") : body;

      var client = new SendGridClient(_apiKey);
      await client.SendEmailAsync(sendGridMessage);
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}