using System;
using UI.Views;
using Windows.ApplicationModel.Store;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UI.CommonControls.CommandBars
{
    public sealed partial class CommandBar : UserControl
    {
        public CommandBar()
        {
            this.InitializeComponent();
        }

        private void ToggleThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.AppSettings.AppTheme == ElementTheme.Dark)
            {
                App.AppSettings.AppTheme = ElementTheme.Light;
            }
            else
            {
                App.AppSettings.AppTheme = ElementTheme.Dark;
            }

            var rootFrame = Window.Current.Content as Frame;

            var currentPage = rootFrame.Content as Page;

            App.AppSettings.CheckTheme(currentPage);
        }

        private void ChangeLanguageToUkrainian_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implement localization
        }

        private void ChangeLanguageToEnglish_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implement localization
        }
    }
}
