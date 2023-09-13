using CloudSuite.Modules.Application.Handlers.Core.Countries;
using CloudSuite.Modules.Application.Handlers.Core.Countries.Responses;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Countries
{
    public class CreateCountryCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidCountryEntity()
        {
            // Arrange
            var command = new CreateCountryCommand
            {
                CountryName = "Test Country",
                Code3 = "TST"
            };

            // Act
            var countryEntity = command.GetEntity();

            // Assert
            Assert.NotNull(countryEntity);
            Assert.Equal(command.Id, countryEntity.Id);
            Assert.Equal(command.CountryName, countryEntity.CountryName);

            // Verificação adicional: Verifica se o país tem um código de 3 caracteres válido.
            bool hasValidCode3 = !string.IsNullOrEmpty(countryEntity.Code3) && countryEntity.Code3.Length == 3;

            // Retorne verdadeiro ou falso com base na validação
            Assert.True(hasValidCode3, "O código de 3 caracteres do país não é válido.");
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateCountryCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateCountryResponse()
        {
            // Arrange
            var command = new CreateCountryCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateCountryResponse>>(command);
        }
    }
}
