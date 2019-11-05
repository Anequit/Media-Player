using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Windows.Media;
using System.Windows;
using media_player.Core;
using System.IO;
using System.Diagnostics;

namespace media_player
{
    public partial class Form1 : Form
    {
        MediaPlayer player = new MediaPlayer();
        MediaController controller = new MediaController();
        Random random = new Random();
        IndexHelper indexHelper = new IndexHelper();

        int index = 0;
        int pastIndex = 0;
        string Path = $@"{Directory.GetCurrentDirectory()}\Media";

        bool repeating = false;
        bool shuffling = false;

        public Form1()
        {
            InitializeComponent();

            if (!Directory.Exists(@".\Media"))
            {
                Directory.CreateDirectory(@".\Media");
            }
            
            List<FileInfo> files = controller.GetMediaMp3(Path);

            if(files.Count == 0)
            {
                MessageBox.Show("Media contains no mp3 files", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start(@".\Media");
                Environment.Exit(1);
            }

            player.Open(controller.MediaPath(Path, files[index]));

            player.MediaEnded += Player_MediaEnded;

            var Mp3 = controller.GetMediaMp3(Path);

            Songname_LBL.Text = Mp3[index].Name;
            volume_lbl.Text = (Volume.Value / 1).ToString();
        }

        private void Player_MediaEnded(object sender, EventArgs e)
        {
            var Mp3 = controller.GetMediaMp3(Path);

            if (!repeating)
            {
                if (!shuffling)
                    index = indexHelper.IndexQueueNext(index, Path, controller);
                else
                    index = indexHelper.ShuffleIndex(index, pastIndex, random, Mp3);
            }
            
            player.Open(controller.MediaPath(Path, Mp3[index]));
            player.Play();
            Songname_LBL.Text = Mp3[index].Name;
        }

        private void Start_BTN_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void Stop_BTN_Click(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void Next_BTN_Click(object sender, EventArgs e)
        {
            var Mp3 = controller.GetMediaMp3(Path);

            if (!shuffling)
                index = indexHelper.IndexQueueNext(index, Path, controller);
            else
                index = indexHelper.ShuffleIndex(index, pastIndex, random, Mp3);
            
            player.Open(controller.MediaPath(Path, controller.GetMediaMp3(Path)[index]));
            player.Play();
            Songname_LBL.Text = Mp3[index].Name;
        }

        private void Back_BTN_Click(object sender, EventArgs e)
        {
            List<FileInfo> Mp3 = controller.GetMediaMp3(Path);

            if (!shuffling)
                index = indexHelper.IndexQueueBack(index, Path, controller);
            else
                index = indexHelper.ShuffleIndex(index, pastIndex, random, Mp3);

            player.Open(controller.MediaPath(Path, controller.GetMediaMp3(Path)[index]));
            player.Play();
            Songname_LBL.Text = Mp3[index].Name;
        }

        private void Volume_Scroll(object sender, EventArgs e)
        {
            volume_lbl.Text = (Volume.Value  / 1).ToString();
            player.Volume = (Volume.Value * 0.01);
        }

        private void Repeat_BTN_CheckedChanged(object sender, EventArgs e)
        {
            if (Repeat_BTN.CheckState == CheckState.Checked)
                repeating = true;

            if (Repeat_BTN.CheckState == CheckState.Unchecked)
                repeating = false;
        }

        private void Shuffle_BTN_CheckedChanged(object sender, EventArgs e)
        {
            if (Shuffle_BTN.CheckState == CheckState.Checked)
                shuffling = true;

            if (Shuffle_BTN.CheckState == CheckState.Unchecked)
                shuffling = false;
        }
    }
}
