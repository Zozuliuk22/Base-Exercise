using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseExercise
{
    internal static class ShowingInformation
    {
        /// <summary>
        /// Show statistic of the dictionary in the format: a word and an amount of the word repeats in the text. 
        /// </summary>
        /// <param name="dictionary">The formed dictionary of words.</param>
        internal static void ShowStatistic(Dictionary<string, WordInText> dictionary)
        {
            Console.WriteLine("\n\tDictionary statistic\n");

            Console.WriteLine(new string('-', 40));
            Console.WriteLine(String.Format("{0, 14}", "Word") + String.Format("{0, 10}", "|") + String.Format("{0, 11}", "Amount"));
            Console.WriteLine(new string('-', 40));

            foreach (var word in dictionary.OrderByDescending(v => v.Value.Frequency))
            {
                Console.WriteLine(String.Format("{0, 19}", word.Key) + String.Format("{0, 5}", "|") + String.Format("{0, 9}", word.Value.Frequency));
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Show such information about the word as an amount of the word repeats in the text and a list of positions in the text - an index of the line and an index of the word in the line. 
        /// </summary>
        /// <param name="word">The chosen word from the dictionary.</param>
        internal static void ShowWordFullInformation(WordInText word)
        {
            Console.WriteLine("Frequency is {0}", word.Frequency);
            Console.WriteLine("\n\tList of positions:\n");

            foreach (var v in word.Positions)
            {
                Console.WriteLine("Line is {0} and word is {1}", v.Item1 + 1, v.Item2 + 1);
            }
        }
    }
}

