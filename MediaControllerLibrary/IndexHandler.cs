using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaControllerLibrary
{
    public class IndexHandler
    {
        private int currentIndex;
        private int previousIndex;

        private int indexMax;
        private int indexMin;

        public IndexHandler(int max, int min)
        {
            this.indexMax = max;
            this.indexMin = min;
        }

        public int GetCurrentIndex()
        {
            // Simply return current index.
            return currentIndex;
        }

        public int IndexBack(int currentIndex, string path, int mp3Count)
        {
            // Decrement currentIndex and check if it's greater than 0
            // If it's less than 0 then overflow into the count of the mp3 folder.

            throw new NotImplementedException();
        }

        public int IndexNext(int currentIndex, string path, int mp3Count)
        {
            // Increment currentIndex and check if it's under the max ammount
            // If it's greater than the max amount then overflow into 0 otherwise increase it.

            throw new NotImplementedException();
        }

        public int ShuffleIndex()
        {
            // Shuffle the index by generating a random index number between 0 and the max ammount

            throw new NotImplementedException();
        }
    }
}
