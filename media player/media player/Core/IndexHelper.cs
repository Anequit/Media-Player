using System;
using System.Collections.Generic;
using System.IO;

namespace media_player.Core
{
    public class IndexHelper
    {
        public int ShuffleIndex(int index, int pastIndex, Random random, List<FileInfo> Mp3)
        {
            pastIndex = index;
            index = random.Next(0, Mp3.Count - 1);

            while (index == pastIndex)
                index = random.Next(0, Mp3.Count - 1);

            return index;
        }

        public int IndexQueueNext(int index, string Path, MediaController controller)
        {
            if (index == controller.GetMediaMp3(Path).Count - 1)
                index = 0;
            else if (index != controller.GetMediaMp3(Path).Count - 1)
                index += 1;

            return index;
        }

        public int IndexQueueBack(int index, string Path, MediaController controller)
        {
            if (index == 0)
                index = controller.GetMediaMp3(Path).Count - 1;
            else if (index != 0)
                index -= 1;

            return index;
        }
    }
}
