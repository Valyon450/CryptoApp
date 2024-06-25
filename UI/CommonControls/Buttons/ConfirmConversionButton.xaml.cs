using System;
using Windows.UI.Xaml.Controls;

namespace UI.CommonControls.Buttons
{
    public sealed partial class ConfirmConversionButton : UserControl
    {
        public event EventHandler Click;
        public ConfirmConversionButton()
        {
            this.InitializeComponent();
            ConvertButton.Click += ConfirmConversionButton_Click;
        }

        private void ConfirmConversionButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
}
