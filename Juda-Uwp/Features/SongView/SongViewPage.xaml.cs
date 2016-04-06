using Juda_Uwp.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Juda_Uwp.Features.SongView
{

    public sealed partial class SongViewPage : Page
    {
        private Song song { get; }

        public SongViewPage()
        {
            this.InitializeComponent();
        }

        async protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var song = e.Parameter as Song;
            songTitle.Text = song.Name;
            songArtist.Text = $"Written by {song.Artist.Name}";
            songText.Text = await (App.Current as App).MediaService.GetSongTextOnly(song.Id);
        }

    }
}
