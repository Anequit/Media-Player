using MediaControllerLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MediaControllerLibrary
{
    public class IndexHandler
    {
        private readonly Random randomizer;

        private int currentIndex = 0;
        private int previousIndex;
        private int indexMax = 0;
        private readonly int indexMin = 0;

        public IndexHandler(List<FileModel> fileModels)
        {
            randomizer = new Random();

            UpdateIndex(fileModels);
        }

        /// <summary>
        /// Get the current index
        /// </summary>
        /// <returns>
        /// Current index
        /// </returns>
        public int GetCurrentIndex() 
            => currentIndex;
        
        /// <summary>
        /// Updates the index max
        /// </summary>
        /// <param name="fileModels"></param>
        public void UpdateIndex(List<FileModel> fileModels)
            => indexMax = fileModels.Count - 1;

        /// <summary>
        /// Moves index back by 1
        /// </summary>
        public void IndexBack()
        {
            // Decrement currentIndex and check if it's greater than 0
            // If it's less than 0 then overflow into the count of the mp3 folder.
            previousIndex = currentIndex;

            if(currentIndex == indexMin)
                currentIndex = indexMax;
            else
                currentIndex -= 1;
        }

        /// <summary>
        /// Moves index forward by 1
        /// </summary>
        public void IndexNext()
        {
            // Increment currentIndex and check if it's under the max ammount
            // If it's greater than the max amount then overflow into 0 otherwise increase it.
            previousIndex = currentIndex;

            if (currentIndex == indexMax)
                currentIndex = indexMin;
            else
                currentIndex += 1;
        }

        /// <summary>
        /// Sets current index to a random number.
        /// </summary>
        public void RandomizeIndex()
        {
            // Shuffle the index by generating a random index number between 0 and the max ammount

            previousIndex = currentIndex;
            
            do
            {
                currentIndex = randomizer.Next(indexMin, indexMax);    
            } while (previousIndex == currentIndex);
        }
    }
}
