using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Contracts.Core
{
    public interface IMediaRepository
    {
        Task<Media> GetByCaption(string caption);

        Task<Media> GetByFileName(string fileName);

        Task<Media> GetByFileSize(int fileSize);

        Task<IEnumerable<Media>> GetList();

        Task Add(Media media);

        void Update(Media media);

        void Remove(Media media);
    }
}
