using Juda_Uwp.Features.Directory;
using Juda_Uwp.Features.Overview;
using Juda_Uwp.Features.Search;
using Juda_Uwp.Features.Settings;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
        private void DirectoryRadioButton_Click(object sender, RoutedEventArgs e) => NavigateIfNecessary(typeof(DirectoryPage), DirectoryRadioButton);
        private void FavoriteRadioButton_Click(object sender, RoutedEventArgs e) { }
        private void PlaylistRadioButton_Click(object sender, RoutedEventArgs e) { }
        private void SettingsRadioButton_Click(object sender, RoutedEventArgs e) => NavigateIfNecessary(typeof(SettingsPage), SettingsRadioButton);

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
