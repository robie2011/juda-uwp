using Juda_Uwp.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Juda_Uwp.Features.SongView
{

    public sealed partial class SongViewPage : Page
    {
        private Song song { get; }

        public SongViewPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var song = e.Parameter as Song;
            songTitle.Text = song.Name;
        }

    }
}
