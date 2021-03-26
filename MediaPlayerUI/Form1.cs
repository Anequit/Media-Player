using MediaControllerLibrary;
using MediaControllerLibrary.Entities;
using System;
using System.Windows.Forms;

namespace MediaPlayerUI
{
    public partial class MediaPlayerForm : Form
    {
        readonly FileHandler fileHandler;
        readonly MediaHandler mediaHandler;

        public MediaPlayerForm()
        {
            InitializeComponent();

            fileHandler = new FileHandler(FileType.mp3);
            fileHandler.BuildFileList();

            mediaHandler = new MediaHandler(fileHandler.GetFileList());

            Songname_LBL.Text = mediaHandler.GetCurrentSong();
            volume_lbl.Text = $"{Volume.Value / 1}";
        }

        private void Start_BTN_Click(object sender, EventArgs e) => mediaHandler.Play();

        private void Stop_BTN_Click(object sender, EventArgs e) => mediaHandler.Pause();

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
            volume_lbl.Text = $"{Volume.Value / 1}";
            mediaHandler.ChangeVolume(Volume.Value);
        }

        private void Repeat_BTN_CheckedChanged(object sender, EventArgs e) => mediaHandler.ToggleRepeat();

        private void Shuffle_BTN_CheckedChanged(object sender, EventArgs e) => mediaHandler.ToggleShuffle();
    }
}
