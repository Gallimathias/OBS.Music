using OBS.Music.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music;

public static class Randomizer
{
    public static IReadOnlyList<Track> Randomize(PlayList playList)
    {
        var tracks = playList.Tracks;

        if (tracks is null)
            throw new ArgumentException($"{nameof(playList.Tracks)} is null");

        var random = new Random();
        var sortedlist = new Track[tracks.Count];
        var sourceList = new List<Track>(tracks);

        for (int i = 0; i < sortedlist.Length; i++)
        {
            var rand = random.Next(0, sourceList.Count);
            var value = sourceList[rand];
            sortedlist[i] = value;
            sourceList.Remove(value);
        }

        return sortedlist;
    }
}
