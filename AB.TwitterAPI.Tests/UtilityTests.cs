using NUnit.Framework;
using AB.TwitterAPI.Utils;

namespace AB.TwitterAPI.Tests
{
    [TestFixture]
    public class UtilityTests
    {
        [Test]
        public void ValidStringLengthShouldReturnTrue()
        {
            string test = "test";
            Assert.IsTrue(ValidationUtil.IsValidLength(0, test.Length + 5, test));
        }

        [Test]
        public void ValidStringLengthEqualToMinShouldReturnTrue()
        {
            string test = string.Empty;
            Assert.IsTrue(ValidationUtil.IsValidLength(0, test.Length + 5, test));
        }

        [Test]
        public void ValidStringLengthEqualToMaxShouldReturnTrue() 
        {
            string test = "test";
            Assert.IsTrue(ValidationUtil.IsValidLength(0, test.Length, test));
        }

        [Test]
        public void InvalidStringLengthGreaterThanMaxShouldReturnFalse()
        {
            string test = "test";
            Assert.IsFalse(ValidationUtil.IsValidLength(0, test.Length - 1, test));
        }

        [Test]
        public void ValidStringLengthNullShouldReturnFalse()
        {
            Assert.IsFalse(ValidationUtil.IsValidLength(0, 10, null));
        }
    }
}