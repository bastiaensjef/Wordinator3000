using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wordinator3000.Application;

namespace Wordinator3000.UnitTests
{
    [TestClass]
    public class WordValidatorTests
    {
        [TestMethod]
        public void IsValid_ShouldReturnFalse_WhenWordIsNull()
        {
            Assert.IsFalse(WordValidator.IsValid(null, 1, 1));
        }

        [TestMethod]
        public void IsValid_ShouldReturnFalse_WhenWordIsEmpty()
        {
            Assert.IsFalse(WordValidator.IsValid("", 1, 1));
        }

        [TestMethod]
        public void IsValid_ShouldReturnFalse_WhenWordLengthIsLessThanMaxChars()
        {
            Assert.IsFalse(WordValidator.IsValid("Word", 1, 3));
        }

        [TestMethod]
        public void IsValid_ShouldReturnFalse_WhenWordLengthIsEqualToMaxCharsAndWordCountIsNot1()
        {
            Assert.IsFalse(WordValidator.IsValid("Word", 2, 4));
        }

        [TestMethod]
        public void IsValid_ShouldReturnTrue_WhenWordLengthIsEqualToMaxCharsAndWordCountIs1()
        {
            Assert.IsTrue(WordValidator.IsValid("Word", 1, 4));
        }

        [TestMethod]
        public void IsValid_ShouldReturnTrue_WhenWordLengthIsLessThanMaxChars()
        {
            Assert.IsTrue(WordValidator.IsValid("Word", 1, 5));
        }
    }
}
