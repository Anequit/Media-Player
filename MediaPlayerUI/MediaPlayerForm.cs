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

            mediaHandler = new MediaHandler(fileHandler.GetFileList());

            mediaHandler.VolumeChangedEvent += MediaHandler_VolumeChangedEvent;
            mediaHandler.SongChangedEvent += MediaHandler_SongChangedEvent;
            mediaHandler.MediaPlayingEvent += MediaHandler_MediaPlayingEvent;
            mediaHandler.MediaPausedEvent += MediaHandler_MediaPausedEvent;
            mediaHandler.MediaFailedToOpen += MediaHandler_MediaFailedToOpen;
        }

        private void MediaHandler_MediaFailedToOpen(object sender, EventArgs e)
        {
            fileHandler.BuildFileList(); // Rebuild file list
            mediaHandler.UpdateMediaHandler(fileHandler.GetFileList()); // Update indexHandler and mediaHandler
            mediaHandler.Next(); // Play the next song.
        }

        private void MediaHandler_MediaPlayingEvent(object sender, EventArgs e) => Text = $"Playing - {mediaHandler.GetCurrentSong()}";

        private void MediaHandler_MediaPausedEvent(object sender, EventArgs e) => Text = $"Paused - {mediaHandler.GetCurrentSong()}";
    
        private void MediaPlayerForm_Load(object sender, EventArgs e) => Songname_Label.Text = mediaHandler.GetCurrentSong();

        private void MediaHandler_SongChangedEvent(object sender, EventArgs e) => Songname_Label.Text = mediaHandler.GetCurrentSong();

        private void MediaHandler_VolumeChangedEvent(object sender, EventArgs e) => Volume_Label.Text = $"Volume: {Volume_TrackBar.Value / 1}";

        private void Start_BTN_Click(object sender, EventArgs e) => mediaHandler.Play();

        private void Stop_BTN_Click(object sender, EventArgs e) => mediaHandler.Pause();

        private void Next_BTN_Click(object sender, EventArgs e) => mediaHandler.Next();

        private void Back_BTN_Click(object sender, EventArgs e) => mediaHandler.Back();

        private void Volume_TrackBar_Scroll(object sender, EventArgs e) => mediaHandler.ChangeVolume(Volume_TrackBar.Value);

        private void Repeat_BTN_CheckedChanged(object sender, EventArgs e) => mediaHandler.ToggleRepeat();

        private void Shuffle_BTN_CheckedChanged(object sender, EventArgs e) => mediaHandler.ToggleShuffle();
    }
}
