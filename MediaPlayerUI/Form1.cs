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

            mediaHandler.SongChangedEvent += MediaHandler_SongChangedEvent;

            Songname_Label.Text = mediaHandler.GetCurrentSong();
        }

        private void MediaHandler_SongChangedEvent(object sender, EventArgs e) => Songname_Label.Text = mediaHandler.GetCurrentSong();

        private void Start_BTN_Click(object sender, EventArgs e) => mediaHandler.Play();

        private void Stop_BTN_Click(object sender, EventArgs e) => mediaHandler.Pause();

        private void Next_BTN_Click(object sender, EventArgs e)
        {
            mediaHandler.Next();
            Songname_Label.Text = mediaHandler.GetCurrentSong();
        }

        private void Back_BTN_Click(object sender, EventArgs e)
        {
            mediaHandler.Back();
            Songname_Label.Text = mediaHandler.GetCurrentSong();
        }

        private void Volume_TrackBar_Scroll(object sender, EventArgs e)
        {
            Volume_Label.Text = $"Volume: {Volume_TrackBar.Value / 1}";
            mediaHandler.ChangeVolume(Volume_TrackBar.Value);
        }

        private void Repeat_BTN_CheckedChanged(object sender, EventArgs e) => mediaHandler.ToggleRepeat();

        private void Shuffle_BTN_CheckedChanged(object sender, EventArgs e) => mediaHandler.ToggleShuffle();

    }
}
