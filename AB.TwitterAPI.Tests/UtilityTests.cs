using AB.TwitterAPI.Utils;
using System.Collections.Generic;
using Xunit;

namespace AB.TwitterAPI.Facts
{
    public class UtilityFacts
    {
        [Fact]
        public void IsValidLength_WithValidStringLength_ReturnsTrue()
        {
            string test = "test";

            var result = ValidationUtil.IsValidLength(0, test.Length + 5, test);
            
            Assert.True(result);
        }

        [Fact]
        public void ValidStringLengthEqualToMinShouldReturnTrue()
        {
            string test = string.Empty;
            Assert.True(ValidationUtil.IsValidLength(0, test.Length + 5, test));
        }

        [Fact]
        public void ValidStringLengthEqualToMaxShouldReturnTrue() 
        {
            string test = "test";
            Assert.True(ValidationUtil.IsValidLength(0, test.Length, test));
        }

        [Fact]
        public void InvalidStringLengthGreaterThanMaxShouldReturnFalse()
        {
            string test = "test";
            Assert.False(ValidationUtil.IsValidLength(0, test.Length - 1, test));
        }

        [Fact]
        public void ValidStringLengthNullShouldReturnFalse()
        {
            Assert.False(ValidationUtil.IsValidLength(0, 10, null));
        }
    }
}