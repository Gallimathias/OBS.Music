using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
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
                SetMinMax(playList);
                if (playList.Count > 0)
                    PlayListIndex = playList.FirstOrDefault().Key;
            }
        }
        public bool Loop { get; set; }
        public int PlayListIndex { get => playListIndex; set => SelectFile(value); }
        public int MaxPlayListNumber { get; private set; }
        public int MinPlayListNumber { get; private set; }
        public KeyValuePair<int, MMDevice> Device { get; set; }

        private WaveOutEvent waveOutEvent;
        private Mp3FileReader mp3;
        private int playListIndex;
        private PlayList playList;
        private bool stopClicked;

        public Player()
        {
            waveOutEvent = new WaveOutEvent();
            PlayList = new PlayList();
            playListIndex = 1;
        }

        public void SetPlayList(PlayList playList) => PlayList = playList;

        public void SelectFile(int value)
        {
            if (PlayList.Count < 1)
                return;

            playListIndex = GetPlayListNumber(value);
            mp3 = new Mp3FileReader(PlayList[playListIndex].File);

            waveOutEvent = new WaveOutEvent();
            waveOutEvent.Init(mp3);
            waveOutEvent.DeviceNumber = Device.Key;
            waveOutEvent.PlaybackStopped += WaveOutEvent_PlaybackStopped;
        }

        public void Dispose()
        {
            waveOutEvent?.Dispose();
            mp3?.Dispose();
            PlayList?.Clear();


            waveOutEvent = null;
            mp3 = null;
            PlayList = null;
            playListIndex = 0;
            Loop = false;
            Device = new KeyValuePair<int, MMDevice>();

        }

        public void Play() => waveOutEvent.Play();
        public void Play(int value)
        {
            SelectFile(value);
            Play();
        }

        public void Pause()
           => waveOutEvent.Pause();

        public void Stop()
        {
            stopClicked = true;
            waveOutEvent.Stop();
        }

        private void WaveOutEvent_PlaybackStopped(object sender, StoppedEventArgs e)
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
            if (list.Count < 1)
                return;

            MinPlayListNumber = list.Min(m => m.Key);
            MaxPlayListNumber = list.Max(m => m.Key);
        }
    }
}
