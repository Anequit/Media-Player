using MediaPlayerLibrary.Models;
using System;
using System.Collections.Generic;

namespace MediaPlayerLibrary
{
    public class IndexHandler
    {
        readonly Random _randomizer;

        int _currentIndex = 0;
        int _previousIndex;
        int _indexMax = 0;

        public IndexHandler(List<FileModel> fileModels)
        {
            _randomizer = new Random();
            _indexMax = fileModels.Count - 1;
        }

        #region Properties

        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                if (value > _indexMax || value < 0)
                    return;

                _currentIndex = value;
            }
        }

        public int IndexMax
        {
            get => _indexMax;
            set => _indexMax = value - 1;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Moves index back by 1
        /// </summary>
        public void IndexBack()
        {
            // Decrement currentIndex and check if it's greater than 0
            // If it's less than 0 then overflow into the count of the mp3 folder.
            _previousIndex = _currentIndex;

            if (_currentIndex <= 0)
                _currentIndex = _indexMax;
            else
                _currentIndex -= 1;
        }

        /// <summary>
        /// Moves index forward by 1
        /// </summary>
        public void IndexNext()
        {
            // Increment currentIndex and check if it's under the max ammount
            // If it's greater than the max amount then overflow into 0 otherwise increase it.
            _previousIndex = _currentIndex;

            if (_currentIndex >= _indexMax)
                _currentIndex = 0;
            else
                _currentIndex += 1;
        }

        /// <summary>
        /// Sets current index to a random number.
        /// </summary>
        public void RandomizeIndex()
        {
            // Shuffle the index by generating a random index number between 0 and the max ammount and if the index is greater than 0

            _previousIndex = _currentIndex;

            do
            {
                _currentIndex = _randomizer.Next(0, _indexMax);
            } while (_previousIndex == _currentIndex && _indexMax > 0);
        }
        #endregion
    }
}
