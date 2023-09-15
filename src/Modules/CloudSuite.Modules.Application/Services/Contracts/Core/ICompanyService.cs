using CloudSuite.Modules.Application.Handlers.Core.Companies;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
    public interface ICompanyService
    {
        Task<CompanyViewModel> GetByFantasyName(string fantasyName);
        
        Task<CompanyViewModel> GetByCnpj(Cnpj cnpj);

        Task Save(CreateCompanyCommand commandCreate);
    }
}
