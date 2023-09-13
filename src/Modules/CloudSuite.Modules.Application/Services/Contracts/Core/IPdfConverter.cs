using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IPdfConverter
    {
        byte[] Convert(string htmlContent);
    }
}