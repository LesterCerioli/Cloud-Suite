using CloudSuite.Modules.Application.Handlers.Core.Vendores;
using CloudSuite.Modules.Application.Handlers.Core.Vendores.Responses;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Vendors
{
    public class CreateVendorCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidVendorEntity()
        {
            // Arrange
            var command = new CreateVendorCommand
            {
                Name = "Vendor Name",
                Slug = "vendor-slug",
                Description = "Vendor Description",
                CreatedOn = DateTimeOffset.Now,
                LatestUpdatedOn = DateTimeOffset.Now,
                IsActive = true,
                IsDeleted = false
            };

            var vendorEntity = command.GetEntity();

            // Assert
            Assert.NotNull(vendorEntity);
            Assert.Equal(command.Id, vendorEntity.Id);
            Assert.Equal(command.Name, vendorEntity.Name);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateVendorCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateVendorResponse()
        {
            // Arrange
            var command = new CreateVendorCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateVendorResponse>>(command);
        }
    }
}
