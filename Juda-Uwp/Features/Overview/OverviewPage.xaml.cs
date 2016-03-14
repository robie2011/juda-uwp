using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

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
