using System.Collections.Generic;

namespace BaseExercise
{
    internal class WordInfo
    {
        private List<(int, int)> _positions;

        public string Word { get; private set; }

        public int Frequency { get { return _positions.Count; } }

        public List<(int, int)> Positions { get { return _positions; } }

        public WordInfo(string word, (int, int) position)
        {
            Word = word;
            _positions = new List<(int, int)>() { position };
        }

        /// <summary>
        /// Add a new position of the word that already exists in the dictionary.
        /// </summary>
        /// <param name="position">One more position of the word.</param>
        public void AddPosition((int, int) position)
        {
            _positions.Add(position);
        }
    }
}

