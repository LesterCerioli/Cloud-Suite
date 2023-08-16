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
        Task<Media> GetMediaUrl(Media media);

        Task<Media> GetMediaUrl(string fileName);

        Task<Media> GetThumbnailUrl(Media media);

        Task<Media> SaveMediaAsync(Stream mediaBinaryStream, string fileName, string MimeType = null);

        Task<Media> DeleteMediaAsync(Media media);

        Task<Media> DeleteMediaAsync(string fileName);
    }
}
