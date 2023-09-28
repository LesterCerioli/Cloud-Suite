using System;
using CloudSuite.Modules.Application.Handlers.Core.Companies.Requests;
using CloudSuite.Modules.Domain.ValueObjects;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.Companies.Requests.Tests
{
    public class CheckCompanyExistsByCnpjRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            var cnpj = new Cnpj("16405682000152"); // Replace with a valid CNPJ value

            // Act
            var request = new CheckCompanyExistsByCnpjRequest(cnpj);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(cnpj, request.Cnpj); // Assert that Cnpj is set correctly
        }
    }
}
