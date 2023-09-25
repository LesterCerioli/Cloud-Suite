using CloudSuite.Modules.Application.Handlers.Core.Vendores.Requests;
using CloudSuite.Modules.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Vendores.Requests
{
    public class CheckVendorExistsByCnpjRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var cnpjValue = "44796875000117"; // Substitua pelo valor desejado

            // Act
            var request = new CheckVendorExistsByCnpjRequest(cnpjValue);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.Cnpj.CnpjNumber.Should().Be(cnpjValue);
        }
    }
}
