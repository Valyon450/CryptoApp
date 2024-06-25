using UI.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UI.CommonControls.Buttons
{
    public sealed partial class HomePageButton : UserControl
    {
        public HomePageButton()
        {
            this.InitializeComponent();
        }

        private void NavigateToMainPage_Click(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Content is Frame rootFrame)
            {
                rootFrame.Navigate(typeof(MainPage));
            }
        }
    }
}
