using CloudSuite.Modules.Application.Handlers.Core.Users;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.ValueObjects;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IUserService
  {
        Task<UserViewModel> GetByCpf(Cpf cpf);

        Task<UserViewModel> GetByEmail(Email email);
        
        Task Save(CreateUserCommand commandCreate);
  }
}