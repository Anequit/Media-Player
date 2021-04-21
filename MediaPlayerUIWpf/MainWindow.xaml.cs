using MediaControllerLibrary;
using MediaControllerLibrary.Entities;
using System;
using System.Windows;

namespace MediaPlayerUIWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly FileHandler fileHandler;
        readonly MediaHandler mediaHandler;

        public MainWindow()
        {
            fileHandler = new FileHandler(FileType.mp3);
            mediaHandler = new MediaHandler(fileHandler.GetFileList());

            mediaHandler.VolumeChangedEvent += MediaHandler_VolumeChangedEvent;
            mediaHandler.SongChangedEvent += MediaHandler_SongChangedEvent;
            mediaHandler.MediaPlayingEvent += MediaHandler_MediaPlayingEvent;
            mediaHandler.MediaPausedEvent += MediaHandler_MediaPausedEvent;
            mediaHandler.MediaFailedToOpen += MediaHandler_MediaFailedToOpen;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => songLabel.Content = mediaHandler.GetCurrentSong();

        private void MediaHandler_MediaFailedToOpen(object sender, EventArgs e)
        {
            fileHandler.BuildFileList(); // Rebuild file list
            mediaHandler.UpdateMediaHandler(fileHandler.GetFileList()); // Update indexHandler and mediaHandler
            mediaHandler.Next(); // Play the next song.
        }

        private void MediaHandler_MediaPlayingEvent(object sender, EventArgs e) => Title = $"Playing - {mediaHandler.GetCurrentSong()}";

        private void MediaHandler_MediaPausedEvent(object sender, EventArgs e) => Title = $"Paused - {mediaHandler.GetCurrentSong()}";

        private void MediaPlayerForm_Load(object sender, EventArgs e) => songLabel.Content = mediaHandler.GetCurrentSong();

        private void MediaHandler_SongChangedEvent(object sender, EventArgs e) => songLabel.Content = mediaHandler.GetCurrentSong();

        private void MediaHandler_VolumeChangedEvent(object sender, EventArgs e) => volumeLabel.Content = $"Volume: {Convert.ToInt32(volumeSlider.Value) / 1}";

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => mediaHandler.ChangeVolume(Convert.ToInt32(e.NewValue));

        private void BackButton_Click(object sender, RoutedEventArgs e) => mediaHandler.Back();

        private void RepeatButton_Click(object sender, RoutedEventArgs e) => mediaHandler.ToggleRepeat();

        private void PlayButton_Click(object sender, RoutedEventArgs e) => mediaHandler.Play();

        private void PauseButton_Click(object sender, RoutedEventArgs e) => mediaHandler.Pause();

        private void ShuffleButton_Click(object sender, RoutedEventArgs e) => mediaHandler.ToggleShuffle();

        private void NextButton_Click(object sender, RoutedEventArgs e) => mediaHandler.Next();
    }
}
