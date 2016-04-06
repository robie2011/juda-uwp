using Juda_Uwp.Features.SongView;
using Juda_Uwp.Services;
using Juda_Uwp.ViewModel;
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
using Windows.UI.Xaml.Navigation;

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
