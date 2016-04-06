using Juda_Uwp.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Juda_Uwp.Features.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void SyncNow_Click(object sender, RoutedEventArgs e)
        {
            IMediaRepository repo = new InternetMediaRepository();
            MediaService mediaService = new MediaService(repo);
        }
    }
}
