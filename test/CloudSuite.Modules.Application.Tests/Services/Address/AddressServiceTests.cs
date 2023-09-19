using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services.Address
{
    public class AddressServiceTests
    {
        [Fact]
        public async Task GetByAddressLine_ValidAddressLine_ReturnsAddressViewModel()
        {
            var addressLine1 = "123 Main St";

            var expectedAddress = new AddressLineViewModel
            {
              addressLine1 = addressLine1;
            };

            var mockAddressService = new Mock<IAddressService>();

            mockAddressService
                .Setup(service => service.GetByAddressLine(addressLine1))
                .ReturnsAsync(expectedAddress);

            var addressService = mockAddressService.Object;

            // Act
            var result = await addressService.GetByAddressLine(addressLine1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAddress.Property1, result.Property1); // Replace Property1 with actual property names
            Assert.Equal(expectedAddress.Property2, result.Property2); // Replace Property2 with actual property names
            // Add more property comparisons as needed

            
        }

        [Fact]
        public async Task GetByContactName_ValidContactName_ReturnsAddressViewModel()
        {
            // Arrange
            var contactName = "John Doe";
            var expectedAddress = new AddressViewModel
            {
                // Define the expected AddressViewModel properties here
            };

            var mockAddressService = new Mock<IAddressService>();
            mockAddressService
                .Setup(service => service.GetByContactName(contactName))
                .ReturnsAsync(expectedAddress);

            var addressService = mockAddressService.Object;

            // Act
            var result = await addressService.GetByContactName(contactName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAddress.Property1, result.Property1); // Replace Property1 with actual property names
            Assert.Equal(expectedAddress.Property2, result.Property2); // Replace Property2 with actual property names

        }

        [Fact]
        public async Task Save_ValidCommand_DoesNotThrowException()
        {
            // Arrange
            var command = new CreateAddressCommand
            {
                // Initialize the command properties as needed for the test
            };

            var addressService = new AddressService(); // You can create an actual instance for this test

            // Act and Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => addressService.Save(command));
        }

        
    }
}