using System;
using System.IO;
using Wordinator3000.Application;

namespace Wordinator3000.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Intro
            Console.WriteLine("Welcome to Wordinator 3000.");
            Console.WriteLine();

            Console.WriteLine("To run the application, please type 'Run' followed by a space, the number of words to use in the combination, another space and the maximum number of characters for the combination formed.");
            Console.WriteLine("For example: 'Run 3 8' will result in rel+ation=relation.");
            Console.WriteLine("By default, Wordinator 3000 will use input.txt to find the words to use. If you wish to provide a different file, add the path to the file as a last parameter.");
            Console.WriteLine(@"For example: 'Run 3 8 C:\Users\MyName\Desktop\'");
            Console.WriteLine("Type exit if you wish to exit Wordinator 3000.");
            Console.WriteLine();

            var userWantsToPlay = true;

            // Check input
            while (userWantsToPlay) 
            {
                var input = Console.ReadLine();

                // Check if user wants to exit
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    userWantsToPlay = false;
                }

                // Check command
                if (CheckAndRun(input))
                {
                    Console.WriteLine("I hope you had fun. Type a new command if you want to go again or type exit if you wish to exit Wordinator 3000.");
                    Console.WriteLine();
                }
                else 
                {
                    Console.WriteLine("Wordinator 3000 doesn't recognize the given command. If you supplied a path to a different file, make sure it is correct and the file exists. Please check your command and try again.");
                    Console.WriteLine();
                }
            }
        }

        private static bool CheckAndRun(string input) 
        {
            var inputParts = input.Split(' ');

            // Should have 3 parts
            if (inputParts.Length != 3 && inputParts.Length != 4) return false;

            // Check for run command
            if (inputParts[0].ToLower() != "run") return false;

            // Check for first parameter (wordcount)
            if (!int.TryParse(inputParts[1], out var wordCount)) return false;

            // Check for second parameter (maxChars)
            if (!int.TryParse(inputParts[2], out var maxChars)) return false;

            // Init filePath
            var filePath = "input.txt";

            // If 3 parameters, check third parameter (filePath)
            if (inputParts.Length == 4) 
            {
                // File doesn't exit
                if(!File.Exists(inputParts[3])) return false;

                filePath = inputParts[3];
            }

            // Read words from file
            var words = File.ReadAllLines(filePath);

            // Build words
            var resultList = new WordBuilder(wordCount, maxChars, words).Build();

            foreach (var word in resultList) 
            {
                Console.WriteLine(word.SumOfWords);
            }

            return true;
        }
    }
}
