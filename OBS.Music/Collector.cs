using Newtonsoft.Json;
using OBS.Music.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music
{
    public class Collector
    {
        public DirectoryInfo DirectoryInfo { get; private set; }
        public List<MusicSourceInfo> MusicInfo { get; private set; }


        public Collector(string folderPath)
        {
            DirectoryInfo = new DirectoryInfo(folderPath);
            MusicInfo = new List<MusicSourceInfo>();
        }

        public void Collect()
        {
            if (!DirectoryInfo.Exists)
                return;

            var msifFiles = DirectoryInfo.GetFiles("*.msif");
            
            foreach (var file in msifFiles)
                MusicInfo.AddRange(JsonConvert.DeserializeObject<MusicSourceInfo[]>(File.ReadAllText(file.FullName)));

        }

        public PlayList GetPlayList()
        {
            var playList = new PlayList();

            for (int i = 0; i < MusicInfo.Count; i++)
                playList.Add(i, MusicInfo[i]);

            return playList;
        }
    }
}
