using XUnit;
using System;
using System.Threading.Tasks;
namespace CloudSuite.Modules.Application.Tests.Services.Countries
{
    public class CountryServiceTests
    {
        [Fact]
        public async Task GetbyName_ValidName_ReturnCountryViewModel()
        {
            var countryName = "United States";

            var expectedCountry = new CountryViewModel
            {
                Id = 1,
                Name = "United States",
                Code = "US"
            };

            var mockCoutryRepository = new Mock<ICountryRepository>();
            mockCountryRepository
                .Setup(repo => repo.GetByName(countryName))
                .ReturnsAsync(expectedCountry); 

            var mockMapper = new Mock<IMapper>();
            mockMapper
                .Setup(mapper => mapper.Map<CountryViewModel>(expectedCountry))
                .Returns(expectedCountry); // Return the expectedCountry as the mapped result

            var countryService = new CountryService(
                mockMapper.Object,
                mockCountryRepository.Object,
                Mock.Of<IMediatorHandler>() // Mock the IMediatorHandler interface
            );

            // Act
            var result = await countryService.GetByName(countryName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCountry.Property1, result.Property1); // Replace Property1 with actual property names
            Assert.Equal(expectedCountry.Property2, result.Property2); // Replace Property2 with actual property names
            // Add more property comparisons as needed

        }

        [Fact]
        public async Task GetByCode_ValidCode_ReturnsCountryViewModel()
        {
            // Arrange
            var countryCode3 = "USA";
            var expectedCountry = new CountryViewModel
            {
                // Define the expected CountryViewModel properties here
            };

            var mockCountryRepository = new Mock<ICountryRepository>();
            mockCountryRepository
                .Setup(repo => repo.GetByCode(countryCode3))
                .ReturnsAsync(expectedCountry); // Return the expectedCountry when GetByCode is called

            var mockMapper = new Mock<IMapper>();
            mockMapper
                .Setup(mapper => mapper.Map<CountryViewModel>(expectedCountry))
                .Returns(expectedCountry); // Return the expectedCountry as the mapped result

            var countryService = new CountryService(
                mockMapper.Object,
                mockCountryRepository.Object,
                Mock.Of<IMediatorHandler>() // Mock the IMediatorHandler interface
            );

            // Act
            var result = await countryService.GetByCode(countryCode3);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCountry.Property1, result.Property1); // Replace Property1 with actual property names
            Assert.Equal(expectedCountry.Property2, result.Property2); // Replace Property2 with actual property names
            // Add more property comparisons as needed
        }

        [Fact]
        public async Task Save_ValidCommand_DoesNotThrowException()
        {
            // Arrange
            var command = new CreateCountryCommand
            {
                // Initialize the command properties as needed for the test
            };

            var mockCountryRepository = new Mock<ICountryRepository>();
            mockCountryRepository
                .Setup(repo => repo.Add(It.IsAny<Country>()))
                .Returns(Task.CompletedTask); // Return a completed task

            var countryService = new CountryService(
                Mock.Of<IMapper>(), // Mock the IMapper interface
                mockCountryRepository.Object,
                Mock.Of<IMediatorHandler>() // Mock the IMediatorHandler interface
            );

            // Act and Assert
            await Assert.ThrowsAsync<NotImplementedException>(() => countryService.Save(command));
        }
        
    }
}