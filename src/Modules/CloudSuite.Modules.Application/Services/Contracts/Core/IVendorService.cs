using CloudSuite.Modules.Application.Handlers.Core.Vendores;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IVendorService
  {
        Task<VendorViewModel> GetByCnpj(Cnpj cnpj);

        Task<VendorViewModel> GetByName(string name);

        Task Save(CreateVendorCommand commandCreate);
  }
}