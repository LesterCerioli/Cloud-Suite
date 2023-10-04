using CloudSuite.Modules.Application.Handlers.Core.Addresses;
using CloudSuite.Modules.Application.Handlers.Core.Addresses.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Tests.Handlers.Addresses
{
    
    public class CreateAddressCommandTests
    {
        public void GetEntity_ReturnsValidAddressEntity()
        {
            var command = new CreateAddressCommand
            {
                ContactName = "John Doe",
                AddressLine1 = "123 Main St",
                //City = new City("CityName", "StateName")
            };

            var addressEntity = command.GetEntity();

            Assert.NotNull(addressEntity);
            //Assert.IsType<AddressEntity>(addressEntity);
            Assert.Equal(command.Id, addressEntity.Id);
            Assert.Equal(command.ContactName, addressEntity.ContactName);
            Assert.Equal(command.AddressLine1, addressEntity.AddressLine1);
            //Assert.Equal(command.City, addressEntity.City);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateAddressCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateAddressResponse()
        {
            // Arrange
            var command = new CreateAddressCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateAddressResponse>>(command);
        }
        
    }
}