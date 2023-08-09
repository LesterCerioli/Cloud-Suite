using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using CloudSuite.Infrastructure.Helpers;

namespace CloudSuite.Infrastructure.Tests
{
    public class EnumHelperTests
    {
       enum Importance
        {
            None,
            Trivial,
            Regular,
            Important,
            Critical
        };

        [Fact]
        public void GetDisplayNameImportanceEnumCriticalShouldReturnsCritical()
        {
            var foo = Importance.Critical.GetDisplayName();
            Assert.Equal("Critical", foo);
        }

        [Fact]
        public void EnumToDictionaryShouldReturnsDictionary()
        {
            var dic = EnumHelper.ToDictionary(typeof(Importance));
            Assert.Equal(5, dic.Count);
        }

        [Fact]
        public void GetDisplayNameImportanceEnumRegularShouldReturnsRegular()
        {
            var enumValue = Importance.Regular;

            var displayName = enumValue.GetDisplayName();

            Assert.Equal("Regular", displayName);
        }

        [Fact]
        public void GetDisplayNameForInvalidEnumValueShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ((Importance)100).GetDisplayName());
        }

        [Fact]
        public void ToDictionaryWithNullEnumTypeShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => EnumHelper.ToDictionary(null));
        }
    }
}







