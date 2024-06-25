using Microsoft.Extensions.DependencyInjection;
using System;
using UI.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UI.Views
{
    public sealed partial class ConverterPage : Page
    {
        private ConverterViewModel ViewModel => (ConverterViewModel)DataContext;

        public ConverterPage()
        {
            this.InitializeComponent();
            DataContext = App.Services.GetRequiredService<ConverterViewModel>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.AppSettings.CheckTheme(this);            
        }

        private void ConfirmConversionButton_Click(object sender, EventArgs e)
        {
            ViewModel.UpdateAmountFromInput();
        }
    }
}
