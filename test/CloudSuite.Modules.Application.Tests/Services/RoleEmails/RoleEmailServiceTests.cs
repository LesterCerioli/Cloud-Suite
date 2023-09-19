using CloudSuite.Modules.Application.Services.Implementations.Core;
using CloudSuite.Modules.Application.ViewModels.Core;
using Microsoft.Extensions.Configuration;
using Moq;
using NetDevPack.Mediator;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CloudSuite.Modules.Application.Tests.Services.RoleEmails
{
    public class RoleEmailServiceTests
    {
        private readonly Mock<IEmailRepository> _emailRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMediatorHandler> _mediatorMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly RoboEmailService _roboEmailService;

        public RoboEmailServiceTests()
        {
            _emailRepositoryMock = new Mock<IEmailRepository>();
            _mapperMock = new Mock<IMapper>();
            _mediatorMock = new Mock<IMediatorHandler>();
            _configurationMock = new Mock<IConfiguration>();

            // Provide your configuration values here or use a configuration provider for testing
            _configurationMock.Setup(x => x.GetSection("SendGrid:ApiKey")).Returns("your-api-key");
            _configurationMock.Setup(x => x.GetSection("SendGrid:FromEmail")).Returns("your-from-email");
            _configurationMock.Setup(x => x.GetSection("SendGrid:FromName")).Returns("your-from-name");

            _roboEmailService = new RoboEmailService(
                _emailRepositoryMock.Object,
                _mapperMock.Object,
                _mediatorMock.Object,
                _configurationMock.Object);
        }

        [Fact]
        public async Task GetBySubject_ShouldReturnRoboEmailViewModel()
        {
            // Arrange
            var subject = "Test Subject";
            var roboEmailEntity = new RoboEmailEntity(); // Replace with your entity

            _emailRepositoryMock
                .Setup(repo => repo.GetBySubject(subject))
                .ReturnsAsync(roboEmailEntity);

            var expectedViewModel = new RoboEmailViewModel(); // Replace with your view model
            _mapperMock.Setup(mapper => mapper.Map<RoboEmailViewModel>(roboEmailEntity)).Returns(expectedViewModel);

            // Act
            var result = await _roboEmailService.GetBySubject(subject);

            // Assert
            Assert.NotNull(result);
            // Add more assertions based on your specific requirements
        }

        [Fact]
        public async Task Save_ShouldCallRepositoryAdd()
        {
            // Arrange
            var createCommand = new CreateRoboEmailCommand(); // Replace with your command

            // Act
            await _roboEmailService.Save(createCommand);

            // Assert
            _emailRepositoryMock.Verify(repo => repo.Add(It.IsAny<YourEntityType>()), Times.Once);
        }

        [Fact]
        public async Task SendEmailAsync_ShouldSendEmail()
        {
            // Arrange
            var emailAddress = "recipient@example.com";
            var subject = "Test Subject";
            var body = "Test Body";

            // Act
            await _roboEmailService.SendEmailAsync(emailAddress, subject, body, isHtml: false);

            // Assert
            // You may need to add assertions based on your email sending logic
        }

        // Add more test methods for other scenarios and edge cases

        public void Dispose()
        {
            _roboEmailService.Dispose();
        }
        
    }
}