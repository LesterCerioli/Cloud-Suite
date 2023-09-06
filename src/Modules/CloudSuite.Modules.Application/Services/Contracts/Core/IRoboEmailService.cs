using CloudSuite.Modules.Application.Handlers.Core.RoboEmails;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IRoboEmailService
  {
    Task SendEmailAsync(string emailAddress, string subject, string body, bool isHtml = false);

    Task<RoboEmailViewModel> GetBySubject(string subject);
    Task Save(CreateRoboEmailCommand commandCreate);
  }
}