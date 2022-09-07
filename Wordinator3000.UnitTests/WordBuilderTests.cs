using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Wordinator3000.Application;

namespace Wordinator3000.UnitTests
{
    [TestClass]
    public class WordBuilderTests
    {
        [TestMethod]
        public void BuildWord_WordCount2_InOrder_SingleResult()
        {
            // Prepare
            var builder = new WordBuilder(2, 6, new string[] { "foo", "bar", "foobar" });
            var words = builder.Build().ToList();

            // Assert
            Assert.AreEqual(1, words.Count());
            Assert.AreEqual("foobar", words[0].FullWord);
        }

        [TestMethod]
        public void BuildWord_WordCount2_NotInOrder_SingleResult()
        {
            // Prepare
            var builder = new WordBuilder(2, 6, new string[] { "bar", "foobar", "foo" });
            var words = builder.Build().ToList();

            // Assert
            Assert.AreEqual(1, words.Count());
            Assert.AreEqual("foobar", words[0].FullWord);
        }

        [TestMethod]
        public void BuildWord_WordCount2_NotInOrder_WithUnusedWords_SingleResult()
        {
            // Prepare
            var builder = new WordBuilder(2, 6, new string[] { "chair", "bar", "door", "foobar", "foo", "closet", "table" });
            var words = builder.Build().ToList();

            // Assert
            Assert.AreEqual(1, words.Count());
            Assert.AreEqual("foobar", words[0].FullWord);
        }

        [TestMethod]
        public void BuildWord_WordCount2_NotInOrder_WithUnusedWords_MultiResult()
        {
            // Prepare
            var builder = new WordBuilder(2, 6, new string[] { "chair", "set", "bar", "door", "cardboard", "foobar", "foo", "closet", "clo" });
            var words = builder.Build().ToList();

            // Assert
            Assert.AreEqual(2, words.Count());
            Assert.IsTrue(words.Any(c => c.FullWord.Equals("foobar")));
            Assert.IsTrue(words.Any(c => c.FullWord.Equals("closet")));
        }

        [TestMethod]
        public void BuildWord_WordCount3_NotInOrder_WithUnusedWords_MultiResult()
        {
            // Prepare
            var builder = new WordBuilder(3, 6, new string[] { "chair", "et", "os", "ar", "door", "cardboard", "foobar", "fo", "closet", "cl", "ob" });
            var words = builder.Build().ToList();

            // Assert
            Assert.AreEqual(2, words.Count());
            Assert.IsTrue(words.Any(c => c.FullWord.Equals("foobar")));
            Assert.IsTrue(words.Any(c => c.FullWord.Equals("closet")));
        }

        [TestMethod]
        public void BuildWord_WordCount5_NotInOrder_WithUnusedWords_MultiResult()
        {
            // Prepare
            var builder = new WordBuilder(5, 10, new string[] { "friendship", "sh", "ie", "friendship", "these", "fr", "are", "some", "ip", "other", "nd", "words", "appreciate" });
            var words = builder.Build().ToList();

            // Assert
            Assert.AreEqual(1, words.Count());
            Assert.IsTrue(words.Any(c => c.FullWord.Equals("friendship")));
        }
    }
}

