using CloudSuite.Modules.Domain.Models.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Domain.Tests.Models
{
    public class DistrictEntityTests
    {
        [Fact]
        public void District_Constructor_Sets_Properties_Correctly()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string name = "SampleDistrict";
            string type = "SampleType";
            string location = "SampleLocation";

            // Act
            var district = new District(id, name, type, location);

            // Assert
            Assert.Equal(id, district.Id);
            Assert.Equal(name, district.Name);
            Assert.Equal(type, district.Type);
            Assert.Equal(location, district.Location);
        }

        [Fact]
        public void District_Default_Constructor_Creates_Instance()
        {
            // Act
            var district = new District();

            // Assert
            Assert.NotNull(district);
        }

        [Fact]
        public void District_States_Collection_Is_Not_Null()
        {
            // Arrange
            var district = new District();

            // Act
            var states = district.States;

            // Assert
            Assert.NotNull(states);
            Assert.IsAssignableFrom<IReadOnlyCollection<State>>(states);
        }

        [Fact]
        public void District_StateId_Property_Can_Be_Set()
        {
            // Arrange
            var district = new District();
            Guid stateId = Guid.NewGuid();

            // Act
            //district.StateId = stateId;

            // Assert
            Assert.Equal(stateId, district.StateId);
        }

        [Fact]
        public void District_Name_Property_Validation()
        {
            // Arrange
            var district = new District();

            // Act
            //Name = "SampleName";

            // Assert
            Assert.Equal("SampleName", district.Name);
        }

        [Fact]
        public void District_Type_Property_Validation()
        {
            // Arrange
            var district = new District();

            // Act
            //district.Type = "SampleType";

            // Assert
            Assert.Equal("SampleType", district.Type);
        }

        [Fact]
        public void District_Location_Property_Validation()
        {
            // Arrange
            var district = new District();

            // Act
            //district.Location = "SampleLocation";

            // Assert
            Assert.Equal("SampleLocation", district.Location);
        }

        [Fact]
        public void District_Name_Required_Validation()
        {
            // Arrange
            var district = new District();

            // Act & Assert
            //Assert.Throws<ValidationException>(() => district.Name = null);
            //Assert.Throws<ValidationException>(() => district.Name = "");
        }

        //[Fact]
        //public void District_Type_Required_Validation()
        //{
            // Arrange
            //var district = new District();

            // Act & Assert
            //Assert.Throws<ValidationException>(() => district.Type = null);
            //Assert.Throws<ValidationException>(() => district.Type = "");
        //}

        //[Fact]
        //public void District_Location_Required_Validation()
        //{
            // Arrange
            //var district = new District();

            // Act & Assert
            //Assert.Throws<ValidationException>(() => district.Location = null);
            //Assert.Throws<ValidationException>(() => district.Location = "");
        //}
    }
}
