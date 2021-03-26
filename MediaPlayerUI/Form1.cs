using MediaControllerLibrary;
using MediaControllerLibrary.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayerUI
{
    public partial class MediaPlayerForm : Form
    {

        /**
        MediaPlayer player = new MediaPlayer();
        MediaController controller = new MediaController();
        Random random = new Random();
        IndexHelper indexHelper = new IndexHelper();

        int index = 0;
        int pastIndex = 0;
        string Path = $@"{Directory.GetCurrentDirectory()}\Media";

        bool repeating = false;
        bool shuffling = false;

        **/
        readonly FileHandler fileHandler;
        readonly MediaHandler mediaHandler;

        public MediaPlayerForm()
        {
            InitializeComponent();

            fileHandler = new FileHandler(FileType.mp3);
            fileHandler.BuildFileList();

            mediaHandler = new MediaHandler(fileHandler.GetFileList());

            Songname_LBL.Text = mediaHandler.GetCurrentSong();
            volume_lbl.Text = (Volume.Value / 1).ToString();
        }

        private void Start_BTN_Click(object sender, EventArgs e) => mediaHandler.Play();

        private void Stop_BTN_Click(object sender, EventArgs e) => mediaHandler.Stop();

        private void Next_BTN_Click(object sender, EventArgs e)
        {
            Songname_LBL.Text = mediaHandler.GetCurrentSong();
            mediaHandler.Next();
        }

        private void Back_BTN_Click(object sender, EventArgs e)
        {
            Songname_LBL.Text = mediaHandler.GetCurrentSong();
            mediaHandler.Back();
        }

        private void Volume_Scroll(object sender, EventArgs e)
        {
            volume_lbl.Text = (Volume.Value / 1).ToString();
            mediaHandler.ChangeVolume(Volume.Value);
        }

        private void Repeat_BTN_CheckedChanged(object sender, EventArgs e) => mediaHandler.ToggleRepeat();

        private void Shuffle_BTN_CheckedChanged(object sender, EventArgs e) => mediaHandler.ToggleShuffle();
    }
}
