using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music
{
    public class Player : IDisposable
    {
        public PlayList PlayList
        {
            get => playList; set
            {
                playList = value;

                if (value == null)
                    return;

                SetMinMax(playList);
                if (playList.Count > 0)
                    PlayListIndex = playList.FirstOrDefault().Key;
            }
        }
        public bool Loop { get; set; }
        public int PlayListIndex { get => playListIndex; set => SelectFile(value); }
        public int MaxPlayListNumber { get; private set; }
        public int MinPlayListNumber { get; private set; }
        public MMDevice Device { get; set; }
        public string RootPath { get; set; }
        public bool IsPalying => directSoundOut != null ? directSoundOut.PlaybackState == PlaybackState.Playing : false;

        public string CurrentName => PlayList.Count > 0 ? PlayList[PlayListIndex].Name : "";
        public string CurrentSource => PlayList.Count > 0 ? PlayList[PlayListIndex].Source : "";
        public string CurrentLicence => PlayList.Count > 0 ? PlayList[PlayListIndex].Licence : "";

        public event EventHandler<StoppedEventArgs> OnMusicIsStopped;

        private DirectSoundOut directSoundOut;
        private Mp3FileReader mp3;
        private int playListIndex;
        private PlayList playList;
        private bool stopClicked;

        public Player()
        {
            directSoundOut = new DirectSoundOut();
            PlayList = new PlayList();
            playListIndex = 1;
            RootPath = @".\";
        }

        public void SetPlayList(PlayList playList) 
            => PlayList = playList;

        public void SelectFile(int value)
        {
            if (PlayList == null || PlayList?.Count < 1 || Device == null)
                return;

            playListIndex = GetPlayListNumber(value);
            var filePath = PlayList[playListIndex].File;

            if (!File.Exists(filePath))
                filePath = Path.Combine(RootPath, PlayList[playListIndex].File);

            if (!File.Exists(filePath))
            {
                SelectFile(value + 1);
                return;
            }

            if (directSoundOut?.PlaybackState != PlaybackState.Stopped)
            {
                directSoundOut?.Stop();
                mp3?.Dispose();
                directSoundOut?.Dispose();
            }

            mp3 = new Mp3FileReader(filePath);
            directSoundOut = new DirectSoundOut(new Guid(Device.ID.Substring(Device.ID.LastIndexOf('.') + 1)))
            {
            };
            directSoundOut.Init(mp3);
            directSoundOut.PlaybackStopped += WaveOutEventPlaybackStopped;
            directSoundOut.PlaybackStopped += (s, e) => OnMusicIsStopped?.Invoke(s, e);
        }

        public void Dispose()
        {
            directSoundOut?.Dispose();
            mp3?.Dispose();
            PlayList?.Clear();


            directSoundOut = null;
            mp3 = null;
            PlayList = null;
            playListIndex = 0;
            Loop = false;
            Device = null;

        }

        public void Play() 
            => directSoundOut.Play();
        public void Play(int value)
        {
            SelectFile(value);
            Play();
        }

        public void Pause()
           => directSoundOut.Pause();

        public void Stop()
        {
            stopClicked = true;
            directSoundOut.Stop();
        }

        private void WaveOutEventPlaybackStopped(object sender, StoppedEventArgs e)
        {

            mp3?.Dispose();

            PlayListIndex++;

            if (Loop && !stopClicked)
                Play();

            stopClicked = false;
        }

        private int GetPlayListNumber(int value)
            => value < MinPlayListNumber ? MaxPlayListNumber : value > MaxPlayListNumber ? MinPlayListNumber : value;

        private void SetMinMax(PlayList list)
        {
            if (list == null || list?.Count < 1)
                return;

            MinPlayListNumber = list.Min(m => m.Key);
            MaxPlayListNumber = list.Max(m => m.Key);
        }
    }
}
