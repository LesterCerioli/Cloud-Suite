using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface IMediaService
    {
       Task<Media> GetByFileName(string fileName);

       Task<Media> GetByFileSize(int fileSize);
    }
}
