using CloudSuite.Modules.Application.Handlers.Core.Companies;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface ICompanyService
  {
        Task<CompanyViewModel> GetByCnpj(string cnpj);

        Task<CompanyViewModel> GetByFantasyName(string fantasyName);

        Task<CompanyViewModel> GetByRegisterName(string registername);

        Task Save(CreateCompanyCommand commandCreate);
  }
}