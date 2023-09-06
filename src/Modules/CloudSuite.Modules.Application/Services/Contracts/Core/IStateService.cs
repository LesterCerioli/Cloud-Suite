using CloudSuite.Modules.Application.Handlers.Core.States;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IStateService
  {
    Task<StateViewModel> GetByName(string stateName);

    Task Save(CreateStateCommand commandCreate);
  }
}