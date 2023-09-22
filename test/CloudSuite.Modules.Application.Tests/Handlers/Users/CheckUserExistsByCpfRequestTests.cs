using CloudSuite.Modules.Application.Handlers.Core.Users.Requests;
using FluentAssertions;
using CloudSuite.Modules.Domain.ValueObjects;
using Moq;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Users
{
    public class CheckUserExistsByCpfRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var cpfNumber = "64194211014"; // Substitua pelo valor desejado
            var cpfMock = new Mock<Cpf>(cpfNumber); // Criar um mock de Cpf com o número desejado

            // Act
            var request = new CheckUserExistsByCpfRequest(cpfMock.Object);

            // Assert
            request.Id.Should().NotBeEmpty();
            request.Cpf.CpfNumber.Should().Be(cpfNumber);
        }
    }
}
