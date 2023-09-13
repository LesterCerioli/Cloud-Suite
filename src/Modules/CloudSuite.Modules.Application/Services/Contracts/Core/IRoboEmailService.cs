using CloudSuite.Modules.Application.Handlers.Core.RoboEmails;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IRoboEmailService
  {
        Task SendEmailAsync(string emailAddress, string subject, string body, bool isHtml = false);

        Task<RoboEmailViewModel> GetBySubject(string subject);

        Task<RoboEmailViewModel> GetByReceivedTime(DateTimeOffset receivedTime);

        Task<RoboEmailViewModel> GetByMessageRecipient(string messageRecipient);

    Task Save(CreateRoboEmailCommand commandCreate);
  }
}