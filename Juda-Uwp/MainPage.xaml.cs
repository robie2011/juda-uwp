using Juda_Uwp.Features.Overview;
using Juda_Uwp.Features.Search;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Juda_Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.MainContentFrame.Navigate(typeof(OverviewPage));
        }

        //private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MainMenuSplitView.IsPaneOpen = !MainMenuSplitView.IsPaneOpen;
        //}

        private void BackRadioButton_Click(object sender, RoutedEventArgs e)
        {
            var frame = DataContext as Frame;
            if (frame?.CanGoBack == true)
            {
                frame.GoBack();
            }
        }

        private void HamburgerRadioButton_Click(object sender, RoutedEventArgs e)
        {
            HamburgerRadioButton.IsChecked = false;
            MainMenuSplitView.IsPaneOpen = !MainMenuSplitView.IsPaneOpen;
        }


        private void OverviewRadioButton_Click(object sender, RoutedEventArgs e) => NavigateIfNecessary(typeof(OverviewPage), OverviewRadioButton);
        private void SearchRadioButton_Click(object sender, RoutedEventArgs e) => NavigateIfNecessary(typeof(SearchPage), SearchRadioButton);
        private void DirectoryRadioButton_Click(object sender, RoutedEventArgs e) { }
        private void FavoriteRadioButton_Click(object sender, RoutedEventArgs e) { }
        private void PlaylistRadioButton_Click(object sender, RoutedEventArgs e) { }
        private void SettingsRadioButton_Click(object sender, RoutedEventArgs e) { }

        private void NavigateIfNecessary(Type pageType, RadioButton radioButton)
        {
            var frame = MainContentFrame;
            var page = frame?.Content as Page;
            if (page?.GetType() != pageType)
            {
                MainContentFrame.Navigate(pageType);
                radioButton.IsChecked = true;
            }
        }
    }
}
