using CloudSuite.Modules.Application.Handlers.Core.States;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IStateService
  {
        Task<StateViewModel> GetByName(string stateName);

        Task<StateViewModel> GetByUF(string uf);

        Task Save(CreateStateCommand commandCreate);
  }
}