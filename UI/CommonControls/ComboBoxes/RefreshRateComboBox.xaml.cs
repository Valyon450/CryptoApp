using System;
using Windows.UI.Xaml.Controls;

namespace UI.CommonControls.ComboBoxes
{
    public sealed partial class RefreshRateComboBox : UserControl
    {
        public event EventHandler<int> RefreshRateChanged;

        public RefreshRateComboBox()
        {
            this.InitializeComponent();
        }

        private void RefreshRateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RefreshRateComboBoxControl.SelectedItem is ComboBoxItem selectedItem)
            {
                int selectedSeconds = int.Parse((string)selectedItem.Tag);
                RefreshRateChanged?.Invoke(this, selectedSeconds);
            }
        }
    }
}
