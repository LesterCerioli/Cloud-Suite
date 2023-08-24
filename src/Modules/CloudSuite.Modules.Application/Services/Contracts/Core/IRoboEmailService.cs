using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IRoboEmailService
    {
        
        Task SendEmailAsync(string emailAddress, string subject, string body, bool isHtml = false);
        

        //Task Save(CreateEmailCommand commandCreate);
    }
}
