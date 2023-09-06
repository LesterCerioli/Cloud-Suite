using CloudSuite.Modules.Application.Handlers.Core.Medias;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  internal interface IMediaService
  {
    Task<MediaViewModel> GetByFileName(string fileName);

    Task Save(CreateMediaCommand commandCreate);
  }
}