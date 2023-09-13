using CloudSuite.Modules.Application.Handlers.Core.Addresses;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;

namespace CloudSuite.Modules.Application.Services.Contracts.Core
{
  public interface IAddressService
  {
        Task<AddressViewModel> GetByContactName(string contactName);
        Task<AddressViewModel> GetByAddressLine(string addressLine1);

        Task Save(CreateAddressCommand commandCreate);
  }
}