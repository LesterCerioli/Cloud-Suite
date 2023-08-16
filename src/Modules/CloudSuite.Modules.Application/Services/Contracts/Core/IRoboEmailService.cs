using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IRoboEmailService
    {
        
        Task<RoboEmail> GetBySubject(string subject);

        Task<RoboEmail> GetByReceivedTime(DateTimeOffset receivedTime);

        Task<RoboEmail> GetByMessageRecipient(string messageRecipient);

        Task SendEmailAsync(string emailAddress, string subject, string body, bool isHtml = false);

        //Task Save(CreateEmailCommand commandCreate);
    
    }
}
