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
        public static Dictionary<string, MMDevice> Devices
            => GetDevices();

        private static readonly MMDeviceEnumerator mMDeviceEnumerator;

        static DeviceManager() 
            => mMDeviceEnumerator = new MMDeviceEnumerator();


        private static Dictionary<string, MMDevice> GetDevices()
        {
            MMDeviceCollection collection = mMDeviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            var tmpDictionary = new Dictionary<string, MMDevice>();

            foreach (var device in collection)
                tmpDictionary.Add(device.ID, device);


            return tmpDictionary;
        }

    }
}
