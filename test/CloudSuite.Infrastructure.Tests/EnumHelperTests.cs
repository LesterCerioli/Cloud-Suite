using Xunit;

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
        
    }
}