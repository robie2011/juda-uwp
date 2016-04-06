using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Juda_Uwp.Features.Overview
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OverviewPage : Page
    {
        public OverviewPage()
        {
            this.InitializeComponent();
            listFavorites.Items.Add("favorite 1");
            listFavorites.Items.Add("favorite 2");
            listFavorites.Items.Add("favorite 3");

            listRecentlyAdded.Items.Add("this is recent song 1");
            listRecentlyAdded.Items.Add("this is recent song 2");
            listRecentlyAdded.Items.Add("this is recent song 3");
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            var filepath = @"ms-appx:/Assets/images/juda_358x358.png";
            logo.Source = new BitmapImage(new Uri(filepath, UriKind.RelativeOrAbsolute));            
        }
    }
}
