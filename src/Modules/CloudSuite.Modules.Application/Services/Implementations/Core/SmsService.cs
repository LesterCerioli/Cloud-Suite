using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Application.Services.Contracts.Core;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class SmsService : ISmsSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            return Task.FromResult(0);
        }
    }
}
