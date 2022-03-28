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

            } while (String.IsNullOrEmpty(path) || !File.Exists(path.Trim()));

            string text = File.ReadAllText(path);


            Dictionary<string, WordInText> dictionary = TextParsing.FormDictionary(text);

            ShowingInformation.ShowStatistic(dictionary);


            var enteredWord = String.Empty;

            do
            {
                Console.Write("Enter the correct word to get detailing information about it: ");

                enteredWord = Console.ReadLine();

            } while (String.IsNullOrEmpty(enteredWord) || !dictionary.ContainsKey(enteredWord.Trim()));

            ShowingInformation.ShowWordFullInformation(dictionary[enteredWord]);
        }
    }
}


