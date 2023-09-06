using CloudSuite.Modules.Application.Handlers.Core.Addresses;
using CloudSuite.Modules.Application.ViewModels.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IAddressService
  {
    Task<AddressViewModel> GetByContactName(string contactName);

    Task Save(CreateAddressCommand commandCreate);
  }
}