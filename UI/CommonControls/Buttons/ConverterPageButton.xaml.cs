using UI.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UI.CommonControls.Buttons
{
    public sealed partial class ConverterPageButton : UserControl
    {
        public ConverterPageButton()
        {
            this.InitializeComponent();
        }

        private void NavigateToConverterPage_Click(object sender, RoutedEventArgs e)
        {
            if (Window.Current.Content is Frame rootFrame)
            {
                rootFrame.Navigate(typeof(ConverterPage));
            }
        }
    }
}
