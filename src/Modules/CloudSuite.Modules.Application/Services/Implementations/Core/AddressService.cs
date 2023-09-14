using CloudSuite.Modules.Application.Handlers.Core.Addresses;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations.Core
{
    public class AddressService : IAddressService
    {
        public async Task<AddressViewModel> GetByAddressLine(string addressLine1)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressViewModel> GetByContactName(string contactName)
        {
            throw new NotImplementedException();
        }

        public async Task Save(CreateAddressCommand commandCreate)
        {
            throw new NotImplementedException();
        }
    }
}
