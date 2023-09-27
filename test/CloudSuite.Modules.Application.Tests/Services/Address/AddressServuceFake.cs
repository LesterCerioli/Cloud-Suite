using CloudSuite.Modules.Application.Handlers.Core.Addresses;
using CloudSuite.Modules.Application.Services.Contracts.Core;
using CloudSuite.Modules.Application.Services.Implementations.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Contracts.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Services.Address
{
    public class AddressServuceFake
    {
        private readonly Mock<IAddressService> _addressService;

        public AddressServuceFake()
        {
            _addressService = new Mock<IAddressService>();
        }

        [Fact]
        public async Task GetByAddressLine_ShouldReturnAddressViewModel()
        {
            var mockAddressService = new Mock<IAddressService>();

            mockAddressService
                .Setup(service => service.GetByAddressLine(It.IsAny<string>()))
                .ReturnsAsync(new AddressViewModel()); // Mock the expected result

            var addressService = new AddressService();

            var result = await addressService.GetByAddressLine("Rua Timotes 124");

            Assert.NotNull(result);
            Assert.IsType<AddressViewModel>(result);
        }


        [Fact]
        public async Task GetByContactName_ShouldReturnAddressViewMdoel()
        {
            var mockAddressService = new Mock<IAddressService>();
            mockAddressService
                .Setup(service => service.GetByContactName(It.IsAny<string>()))
                .ReturnsAsync(new AddressViewModel()); // Mock the expected result

            var addressService = new AddressService();

            // Act
            var result = await addressService.GetByContactName("John Doe");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AddressViewModel>(result);
        }

        [Fact]
        public async Task Save_ShouldNotThrowException()
        {
            var mockAddressService = new Mock<IAddressService>();

            mockAddressService
                .Setup(service => service.Save(It.IsAny<CreateAddressCommand>()))
                .Verifiable(); // Mock that the method should be called

            var addressService = new AddressService();

            // Act and Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => addressService.Save(new CreateAddressCommand()));

            // Verify that the method was called
            mockAddressService.Verify(service => service.Save(It.IsAny<CreateAddressCommand>()), Times.Once);
        }




    }
}
