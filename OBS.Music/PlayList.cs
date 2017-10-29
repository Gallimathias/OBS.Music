using OBS.Music.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music
{
    public class PlayList : Dictionary<int, MusicSourceInfo>
    {
        private Random random;

        public PlayList()
        {
            random = new Random();
        }

        public void Randomize()
        {
            var list = new List<MusicSourceInfo>();
            int i;

            list.AddRange(Values.ToArray());            
            
            Clear();

            while (list.Count != 0)
            {
                i = random.Next(0, list.Count);
                Add(Count + 1, list[i]);
                list.RemoveAt(i);
            }
        }
    }
}
