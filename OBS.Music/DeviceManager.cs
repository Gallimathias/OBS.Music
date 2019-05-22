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

        private static readonly MMDeviceEnumerator mMDeviceEnumerator;

        static DeviceManager() 
            => mMDeviceEnumerator = new MMDeviceEnumerator();

        private static Dictionary<int, MMDevice> GetDevices()
        {
            MMDeviceCollection collection = mMDeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            var tmpDictionary = new Dictionary<int, MMDevice>();

            for (var i = 0; i < collection.Count; i++)
                tmpDictionary.Add(i, collection[i]);

            return tmpDictionary;
        }

    }
}
