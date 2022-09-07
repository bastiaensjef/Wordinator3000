using System.Collections.Generic;
using System.Linq;

namespace Wordinator3000.Application
{
    public class WordBuilder
    {
        private readonly int _wordCount;
        private readonly int _maxChars;
        private readonly IEnumerable<string> _words;
        private List<string> _validWords;
        private List<string> _possibleFinalWords;
        private List<WordCombo> _finalWords;
        private WordCombo _wordInProgress;

        public WordBuilder(int wordCount, int maxChars, IEnumerable<string> words)
        {
            _wordCount = wordCount;
            _maxChars = maxChars;
            _words = words;
        }

        public IEnumerable<WordCombo> Build()
        {
            // Get the words that are valid for the given parameters to use for building final words
            _validWords = _words.Where(w => WordValidator.IsValid(w, _wordCount, _maxChars)).ToList();

            // Get the possible final words
            _possibleFinalWords = _words.Where(w => w.Length == _maxChars).ToList();

            // Init final list
            _finalWords = new List<WordCombo>();

            // Create WordCombo
            _wordInProgress = new WordCombo(_wordCount);

            // Build word
            LoopTheLoops(0);

            return _finalWords;
        }

        private void LoopTheLoops(int currentWordCount)
        {
            foreach (var word in _validWords)
            {
                _wordInProgress[currentWordCount] = word;

                if (currentWordCount + 1 == _wordCount)
                {
                    // If length of wordInProgress exceeds maxChars, skip
                    if (_wordInProgress.FullWord.Length > _maxChars) continue;

                    // If length of wordInProgress equals maxChars, we might have a possible winner. Check the possible final words list
                    if (_wordInProgress.FullWord.Length == _maxChars && _possibleFinalWords.Contains(_wordInProgress.FullWord))
                    {
                        // Winner! Add it to the finalList
                        var winnerWord = new WordCombo((string[])_wordInProgress.Parts.Clone());

                        // Do not add duplicates (not sure why there are duplicates. Something is wrong)
                        if (!_finalWords.Any(f => Enumerable.SequenceEqual(f.Parts, winnerWord.Parts)))
                        {
                            _finalWords.Add(winnerWord);
                        }
                    }
                }
                else
                {
                    LoopTheLoops(currentWordCount + 1);
                }
            }
        }
    }
}
