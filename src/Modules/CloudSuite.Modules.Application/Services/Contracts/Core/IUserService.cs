using CloudSuite.Modules.Application.Handlers.Core.Users;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.ValueObjects;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IUserService
  {
    Task<UserViewModel> GetByCpf(Cpf cof);

    Task Save(CreateUserCommand commandCreate);
  }
}