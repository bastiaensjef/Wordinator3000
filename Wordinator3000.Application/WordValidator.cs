namespace Wordinator3000.Application
{
    public static class WordValidator
    {
        public static bool IsValid(string word, int wordCount, int maxChars)
        {
            // Check for empty word
            if (string.IsNullOrEmpty(word)) return false;

            // If the word is longer than the maxChars, it cannot be used
            if (word.Length > maxChars) return false;

            // if the word is as long as maxChars, it can be used, but only if wordCount = 1
            if (word.Length == maxChars && wordCount != 1) return false;

            return true;
        }
    }
}
