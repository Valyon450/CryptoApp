using System;
using Windows.UI.Xaml.Controls;

namespace UI.CommonControls.Buttons
{
    public sealed partial class CandlesPageButton : UserControl
    {

        public event EventHandler Click;

        public CandlesPageButton()
        {
            this.InitializeComponent();
            CandlesButton.Click += CandlesButton_Click;
        }

        private void CandlesButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
}
