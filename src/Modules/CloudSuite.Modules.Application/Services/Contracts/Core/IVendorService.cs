using CloudSuite.Modules.Application.Handlers.Core.Vendores;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.ValueObjects;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IVendorService
  {
    Task<VendorViewModel> GetByCnpj(Cnpj cnpj);

    Task Save(CreateVendorCommand commandCreate);
  }
}