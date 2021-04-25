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
            fileHandler.BuildFileList();

            mediaHandler = new MediaHandler(fileHandler.GetFileList());

            mediaHandler.MediaOpenedEvent += MediaHandler_MediaOpenedEvent;
            mediaHandler.VolumeChangedEvent += MediaHandler_VolumeChangedEvent;
            mediaHandler.SongChangedEvent += MediaHandler_SongChangedEvent;
            mediaHandler.MediaPlayingEvent += MediaHandler_MediaPlayingEvent;
            mediaHandler.MediaPausedEvent += MediaHandler_MediaPausedEvent;
            mediaHandler.MediaFailedEvent += MediaHandler_MediaFailedEvent;

            InitializeComponent();
        }

        private void MediaHandler_MediaOpenedEvent(object sender, EventArgs e) => SetupSeekSlider();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = $"Paused - {mediaHandler.GetCurrentSong().Name}";
            songLabel.Content = mediaHandler.GetCurrentSong().Name;

            //mediaHandler.Open();
        }

        private void MediaHandler_MediaFailedEvent(object sender, EventArgs e)
        {
            fileHandler.BuildFileList();
            mediaHandler.UpdateMediaHandler(fileHandler.GetFileList());
            mediaHandler.Next();
        }

        private void MediaHandler_SongChangedEvent(object sender, EventArgs e) => songLabel.Content = mediaHandler.GetCurrentSong().Name;

        private void MediaHandler_MediaPlayingEvent(object sender, EventArgs e) => Title = $"Playing - {mediaHandler.GetCurrentSong().Name}";

        private void MediaHandler_MediaPausedEvent(object sender, EventArgs e) => Title = $"Paused - {mediaHandler.GetCurrentSong().Name}";

        private void MediaHandler_VolumeChangedEvent(object sender, EventArgs e) => volumeLabel.Content = $"Volume: {Convert.ToInt32(volumeSlider.Value) / 1}";

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => mediaHandler.ChangeVolume(Convert.ToInt32(e.NewValue));

        private void BackButton_Click(object sender, RoutedEventArgs e) => mediaHandler.Back();

        private void RepeatButton_Click(object sender, RoutedEventArgs e) => mediaHandler.ToggleRepeat();

        private void PlayButton_Click(object sender, RoutedEventArgs e) => mediaHandler.Play();

        private void PauseButton_Click(object sender, RoutedEventArgs e) => mediaHandler.Pause();

        private void ShuffleButton_Click(object sender, RoutedEventArgs e) => mediaHandler.ToggleShuffle();

        private void NextButton_Click(object sender, RoutedEventArgs e) => mediaHandler.Next();

        private void SetupSeekSlider()
        {
            seekSlider.Maximum = mediaHandler.GetCurrentSongDuration();
            seekSlider.Minimum = 0;
            seekSlider.Value = 0;
        }

        private void SeekSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            mediaHandler.Seek(seekSlider.Value);

            mediaHandler.Play();
        }

        private void SeekSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e) => mediaHandler.Pause();
    }
}
