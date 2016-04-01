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

namespace Juda_Uwp.Features
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

            // var repo = new InternetMediaRepository(); // TODO: use the media service created in App.xaml.cs
            this.ViewModel = new SongViewModel(null);
        }

    }
}
