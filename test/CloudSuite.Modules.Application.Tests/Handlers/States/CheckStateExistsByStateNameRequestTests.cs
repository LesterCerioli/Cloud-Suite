using System;
using CloudSuite.Modules.Application.Handlers.Core.States.Requests;
using Xunit;

namespace CloudSuite.Modules.Application.Handlers.Core.States.Requests.Tests
{
    public class CheckStateExistsByStateNameRequestTests
    {
        [Fact]
        public void Constructor_SetsProperties()
        {
            // Arrange
            string stateName = "TestStateName";

            // Act
            var request = new CheckStateExistsByStateNameRequest(stateName);

            // Assert
            Assert.NotEqual(Guid.Empty, request.Id); // Assert that Id is not empty
            Assert.Equal(stateName, request.StateName); // Assert that StateName is set correctly
        }
    }
}
