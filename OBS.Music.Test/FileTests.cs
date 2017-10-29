using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using OBS.Music.JSON;

namespace OBS.Music.Test
{
    [TestClass]
    public class FileTests
    {
        [TestMethod]
        public void CreateFile()
        {
            var list = new List<MusicSourceInfo>
            {
                new MusicSourceInfo()
                {
                    Name = "Hot Swing",
                    Source = "Kevin MacLeod (incompetech.com)",
                    File = @"D:\Projekte\Stream\Musik\Hot Swing.mp3",
                    Licence = "CC 3.0"
                }
            };

            var raw = JsonConvert.SerializeObject(list.ToArray(), Formatting.Indented);

            var file = new FileInfo(Path.Combine(@"D:\Projekte\Stream\Musik", "music.msif"));

            File.AppendAllText(file.FullName, raw);
        }

        [TestMethod]
        public void ReadFile()
        {
        }
    }
}
