using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wordinator3000.Application;

namespace Wordinator3000.UnitTests
{
    [TestClass]
    public class WordComboTests
    {
        [TestMethod]
        public void WordCombo_FullWordTest_SinglePart()
        {
            // Prepare
            var combo = new WordCombo(new string[] { "SinglePart"});

            // Assert
            Assert.AreEqual("SinglePart", combo.FullWord);
        }

        [TestMethod]
        public void WordCombo_FullWordTest_MultipleParts()
        {
            // Prepare
            var combo = new WordCombo(new string[] { "Part1", "Part2", "Part3" });

            // Assert
            Assert.AreEqual("Part1Part2Part3", combo.FullWord);
        }
        [TestMethod]
        public void WordCombo_SumOfWordsTest_SinglePart()
        {
            // Prepare
            var combo = new WordCombo(new string[] { "SinglePart" });

            // Assert
            Assert.AreEqual("SinglePart=SinglePart", combo.SumOfWords);
        }

        [TestMethod]
        public void WordCombo_SumOfWordsTest_MultipleParts()
        {
            // Prepare
            var combo = new WordCombo(new string[] { "Part1", "Part2", "Part3" });

            // Assert
            Assert.AreEqual("Part1+Part2+Part3=Part1Part2Part3", combo.SumOfWords);
        }
    }
}
