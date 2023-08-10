using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message, bool isHtml = false);
    }
}
