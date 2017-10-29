using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music
{
    public static class DeviceManager
    {
        public static Dictionary<int, MMDevice> Devices
            => GetDevices();

        private static MMDeviceEnumerator mMDeviceEnumerator;

        static DeviceManager()
        {
            mMDeviceEnumerator = new MMDeviceEnumerator();
        }

        private static Dictionary<int, MMDevice> GetDevices()
        {
            var collection = mMDeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            var tmpDictionary = new Dictionary<int, MMDevice>();

            for (int i = 0; i < collection.Count; i++)
                tmpDictionary.Add(i + 1, collection[i]);

            return tmpDictionary;
        }

    }
}
