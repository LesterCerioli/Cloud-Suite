using CloudSuite.Modules.Application.Handlers.Core.Companies;
using CloudSuite.Modules.Application.Handlers.Core.Companies.Responses;
using CloudSuite.Modules.Domain.Models.Core;
using CloudSuite.Modules.Domain.ValueObjects;
using MediatR;
using System;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Handlers.Companies
{
    public class CreateCompanyCommandTests
    {
        [Fact]
        public void GetEntity_ReturnsValidCompanyEntity()
        {
            // Arrange
            var cnpj = new Cnpj("12345678901234");
            var fantasyName = "Fantasy Company";
            var registerName = "Register Company";
            //var address = new Address("123 Main Street", "City", "State", "12345");

            var command = new CreateCompanyCommand
            {
                Cnpj = cnpj,
                FantasyName = fantasyName,
                RegisterName = registerName,
                //Address = address
            };

            var companyEntity = command.GetEntity();

            // Assert
            Assert.NotNull(companyEntity);
            Assert.Equal(command.Id, companyEntity.Id);
            Assert.Equal(command.Cnpj, companyEntity.Cnpj);
            Assert.Equal(command.FantasyName, companyEntity.FantasyName);
        }

        [Fact]
        public void Id_IsGeneratedOnCreation()
        {
            // Arrange
            var command = new CreateCompanyCommand();

            // Act

            // Assert
            Assert.NotEqual(Guid.Empty, command.Id);
        }

        [Fact]
        public void RequestType_IsIRequestOfCreateCompanyResponse()
        {
            // Arrange
            var command = new CreateCompanyCommand();

            // Act

            // Assert
            Assert.IsAssignableFrom<IRequest<CreateCompanyResponse>>(command);
        }
    }
}
