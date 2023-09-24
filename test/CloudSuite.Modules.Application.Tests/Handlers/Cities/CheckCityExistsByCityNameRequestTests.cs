using CloudSuite.Modules.Application.Handlers.Core.Cities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Tests.Handlers.Cities
{
    public class CheckCityExistsByCityNameRequestTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var cityName = "City_Name";

            // Act
            var request = new CheckCityExistsByCityNameRequest(cityName);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id);
            Assert.Equal(cityName, request.CityName);
        }
    }
}
