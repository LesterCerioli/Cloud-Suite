namespace CloudSuite.Modules.Core.Application.Services.Contracts
{
    public interface IAddressService
    {
        Task<AddressViewModel> GetByContactName(string contactName);

        Task<AddressViewModel> GetByAddressLine(string addressLine1);

        //Task Save(CreateAddressCommand commandCreate);
         
    }
}