using CloudSuite.Modules.Application.Handlers.Core.AppSettings;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using NetDevPack.Mediator;
using AutoMapper;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
  public class AppSettingService : IAppSettingService
  {
    private readonly IMediatorHandler _mediator;

    private readonly IMapper _mapper;

    private readonly IAppSettingRepository _appSettingRepository;

    public AppSettingService(IAppSettingRepository appSettingRepository, IMapper mapper, IMediatorHandler mediator)
    {
      _mediator = mediator;
      _mapper = mapper;
      _appSettingRepository = appSettingRepository;
    }

    public async Task<AppSettingViewModel> GetByAppSetting(string value)
    {
      return _mapper.Map<AppSettingViewModel>(await _appSettingRepository.GetByAppSetting(value));
    }

    public async Task Save(CreateAppSettingCommand commandCreate)
    {
      await _appSettingRepository.Add(commandCreate.GetEntity());
    }

    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}