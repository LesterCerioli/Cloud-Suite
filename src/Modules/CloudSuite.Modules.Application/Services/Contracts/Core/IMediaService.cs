using CloudSuite.Modules.Application.Handlers.Core.Medias;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IMediaService
  {
        Task<MediaViewModel> GetByCaption(string caption);

        Task<MediaViewModel> GetByFileName(string fileName);

        Task<MediaViewModel> GetByFileSize(int fileSize);

        Task Save(CreateMediaCommand commandCreate);
  }
}