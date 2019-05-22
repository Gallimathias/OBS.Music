using NAudio.CoreAudioApi;
using Newtonsoft.Json;
using OBS.Music.JSON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS.Music.GUI
{
    public partial class Dashboard : Form
    {       
        private readonly Player player;
        private readonly HttpService httpService;

        public Dashboard()
        {
            InitializeComponent();

            player = new Player
            {
                Loop = true
            };

            httpService = new HttpService("http://*:10957/", player);

            foreach (KeyValuePair<int, MMDevice> device in DeviceManager.Devices)
                OutputComboBox.Items.Add(new ComboBoxItem(device.Value, device.Key));

            OutputComboBox.SelectedIndexChanged += OutputComboBoxSelectedIndexChanged;
            player.OnMusicIsStopped += PlayerOnMusicIsStopped;
            PlayListBox.SelectedIndexChanged += PlayListBoxSelectedIndexChanged;

            LoadFile();
            httpService.Start();
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            SaveFile();

            httpService?.Stop();
            player?.Stop();
            player?.Dispose();
            base.OnClosing(e);
        }

        private void PlayerOnMusicIsStopped(object sender, NAudio.Wave.StoppedEventArgs e) 
            => PlayListBox.SelectedIndex = player.PlayListIndex - 1;

        private void PlayListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlayListBox.SelectedIndex + 1 == player.PlayListIndex)
                return;

            var playing = player.IsPalying;

            if (playing)
                player.Stop();

            player.PlayListIndex = PlayListBox.SelectedIndex + 1;

            if (playing)
                player.Play();
        }

        private void OutputComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (ComboBoxItem)OutputComboBox.SelectedItem;

            player.Device = new KeyValuePair<int, MMDevice>(item.Index, item.Device);
            player.PlayListIndex = player.PlayListIndex;
        }

        private void DirectoryAssistButtonClick(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    DirectoryBox.Text = dialog.SelectedPath;
            }
        }

        private void DirectoryBoxTextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DirectoryBox.Text))
                DirectoryBox.Text = @".\";

            player.RootPath = DirectoryBox.Text;

            var collector = new Collector(DirectoryBox.Text);

            if (!collector.DirectoryInfo.Exists)
                return;

            collector.Collect();
            PlayList list = collector.GetPlayList();
            list.Randomize();

            if (list.Count < 1)
                return;

            player.PlayList = list;

            Task.Run(() =>
            {
                while (!PlayListBox.IsHandleCreated)
                    Thread.Sleep(1);

                foreach (KeyValuePair<int, MusicSourceInfo> item in player.PlayList.ToList())
                {
                    PlayListBox.Invoke(new MethodInvoker(() =>
                    {
                        PlayListBox.Items.Add($"{item.Key}. {item.Value.Name}");
                    }));
                }

                PlayListBox.Invoke(new MethodInvoker(() =>
                {
                    PlayListBox.SelectedItem = PlayListBox.Items[0];
                }));
            });
        }

        private void PlayButtonClick(object sender, EventArgs e) 
            => player.Play();

        private void StopButtonClick(object sender, EventArgs e) 
            => player.Stop();

        private void PauseButtonClick(object sender, EventArgs e) 
            => player.Pause();

        private void CreateNewSourceFileToolStripMenuItemClick(object sender, EventArgs e)
        {
            var raw = JsonConvert.SerializeObject(new List<MusicSourceInfo>() { new MusicSourceInfo() }, Formatting.Indented);

            var file = new FileInfo(Path.Combine(DirectoryBox.Text, "music.msif"));

            File.AppendAllText(file.FullName, raw);

        }

        private void SaveFile()
        {
            var list = new Dictionary<string, string>()
            {
                ["Path"] = DirectoryBox.Text,
                ["OutputDevice"] = OutputComboBox.SelectedIndex.ToString()
            };

            var file = new FileInfo(@".\main.opt");

            if (file.Exists)
                file.Delete();

            File.AppendAllText(file.FullName, JsonConvert.SerializeObject(list, Formatting.Indented));
        }

        private void LoadFile()
        {
            var file = new FileInfo(@".\main.opt");

            if (!file.Exists)
                return;

            Dictionary<string, string> list = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(file.FullName));

            DirectoryBox.Text = list["Path"];
            OutputComboBox.SelectedIndex = int.Parse(list["OutputDevice"]);
            player.PlayListIndex = player.PlayListIndex;
        }

        private void CloseToolStripMenuItemClick(object sender, EventArgs e) 
            => Close();

        private class ComboBoxItem
        {
            public MMDevice Device { get; private set; }
            public int Index { get; private set; }

            public ComboBoxItem(MMDevice device, int index)
            {
                Device = device;
                Index = index;
            }

            public override string ToString() 
                => Device.FriendlyName;
        }
    }
}
