using System;
using System.Collections.Generic;
using System.IO;

namespace BaseExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = String.Empty;

            do
            {
                Console.WriteLine("Please, enter the correct path to the file with the text that you want to use.\n" +
                    @"An example: C:\Games\Favourite games\description.txt" + "\n" +
                    "Or if your file is near the exe file of this program, please, enter just a file name.\n" +
                    "An example: text.txt");
                Console.Write("\nEnter the path: ");

                path = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(path) || !File.Exists(path.Trim()));

            string text = String.Empty;

            try
            {
                text = File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception message: {ex.Message}");
            }

            Dictionary<string, WordInfo>  dictionary = TextParser.FormDictionary(text);

            ConsoleViewer.ShowStatistic(dictionary);


            if (dictionary.Count == 0)
            {
                Console.WriteLine("No word is in your dictionary.");
            }
            else
            {
                var enteredWord = String.Empty;

                do
                {
                    Console.Write("Enter the correct word to get detailing information about it: ");

                    enteredWord = Console.ReadLine();

                } while (String.IsNullOrWhiteSpace(enteredWord) || !dictionary.ContainsKey(enteredWord.Trim()));

                ConsoleViewer.ShowWordFullInformation(dictionary[enteredWord]);
            }                
        }
    }
}


