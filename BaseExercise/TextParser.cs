using System;
using System.Collections.Generic;

namespace BaseExercise
{
    internal static class TextParser
    {
        /// <summary>
        /// Form a dictionary from the text in the WordInText object format: for every word added its value and positions in the text.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The formed word dictionary that is based on the text.</returns>
        internal static Dictionary<string, WordInfo> FormDictionary(string text)
        {
            var dictionary = new Dictionary<string, WordInfo>();

            text = ClearSpecialSymbols(text);
            string[] lines = text.Split('\n');

            for (var i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Trim().ToLower().Split(' ');

                for (var j = 0; j < words.Length; j++)
                {
                    if (!dictionary.ContainsKey(words[j]) && !String.IsNullOrEmpty(words[j]))
                    {
                        dictionary.Add(words[j], new WordInfo(word: words[j], position: (i, j)));
                    }
                    else
                    {
                        dictionary[words[j]].AddPosition((i, j));
                    }
                }
            }

            return dictionary;
        }

        /// <summary>
        /// Remove from the text special symbols such as punctuation marks and open/close symbols.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <returns>The text without special symbols.</returns>
        internal static string ClearSpecialSymbols(string text)
        {
            char[] specialSymbols = { '.', ',', ':', ';', '"', '!', '?', '<', '>', '(', ')', '[', ']', '{', '}', '/', '\\', '|' };

            foreach (var c in specialSymbols)
                text = text.Replace(c.ToString(), "");

            return text;
        }
    }
}

