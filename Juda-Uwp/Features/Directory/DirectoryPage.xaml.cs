using Juda_Uwp.Features.SongView;
using Juda_Uwp.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Juda_Uwp.Features.Directory
{
    /// <summary>
    /// Directory Page
    /// </summary>
    public sealed partial class DirectoryPage : Page
    {
        private SongViewModel ViewModel { get; set; }

        public DirectoryPage()
        {
            this.InitializeComponent();

            var mediaService = (App.Current as App).MediaService;
            this.ViewModel = new SongViewModel(mediaService);
        }

        private void ChooseSong(object sender, TappedRoutedEventArgs e)
        {
            var song = SongDirectory.SelectedItem;
            this.Frame.Navigate(typeof(SongViewPage), song);
        }
    }
}
