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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS.Music.GUI
{
    public partial class Dashboard : Form
    {
        class ComboBoxItem
        {
            public MMDevice Device { get; private set; }
            public int Index { get; private set; }

            public ComboBoxItem(MMDevice device, int index)
            {
                Device = device;
                Index = index;
            }

            public override string ToString() => Device.FriendlyName;
        }

        private Player player;

        public Dashboard()
        {
            InitializeComponent();

            player = new Player
            {
                Loop = true
            };

            foreach (var device in DeviceManager.Devices)
                OutputComboBox.Items.Add(new ComboBoxItem(device.Value, device.Key));

            OutputComboBox.SelectedIndexChanged += OutputComboBox_SelectedIndexChanged;
        }

        private void OutputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (ComboBoxItem)OutputComboBox.SelectedItem;
            player.Device = new KeyValuePair<int, MMDevice>(item.Index, item.Device);
        }

        private void DirectoryAssistButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    DirectoryBox.Text = dialog.SelectedPath;
            }
        }

        private void DirectoryBox_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(DirectoryBox.Text))
                DirectoryBox.Text = @".\";

            var collector = new Collector(DirectoryBox.Text);

            if (!collector.DirectoryInfo.Exists)
                return;

            collector.Collect();
            var list = collector.GetPlayList();
            list.Randomize();

            if (list.Count < 1)
                return;

            player.PlayList = list;

            Task.Run(() =>
            {
                foreach (var item in player.PlayList.ToList())
                {
                    PlayListBox.Invoke(new MethodInvoker(() =>
                    {
                        PlayListBox.Items.Add($"{item.Key}. {item.Value.Name}");
                    }));
                }

                PlayListBox.Invoke(new MethodInvoker(() => {
                    PlayListBox.SelectedItem = PlayListBox.Items[0];
                }));
            });
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void CreateNewSourceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var raw = JsonConvert.SerializeObject(new List<MusicSourceInfo>() { new MusicSourceInfo() }, Formatting.Indented);

            var file = new FileInfo(Path.Combine(DirectoryBox.Text, "music.msif"));

            File.AppendAllText(file.FullName, raw);

        }
    }
}
