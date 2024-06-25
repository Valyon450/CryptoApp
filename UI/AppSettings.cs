using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Storage;
using Windows.UI.Xaml;

namespace UI
{
    public class AppSettings
    {
        private ElementTheme _appTheme;
        private const string LanguageKey = "AppLanguage";

        private readonly ApplicationDataContainer localSettings;

        public AppSettings()
        {
            localSettings = ApplicationData.Current.LocalSettings;
        }

        public ElementTheme AppTheme
        {
            get => _appTheme;
            set
            {
                _appTheme = value;
                OnPropertyChanged();
            }
        }

        public string AppLanguage
        {
            get
            {
                return localSettings.Values[LanguageKey]?.ToString();
            }
            set
            {
                localSettings.Values[LanguageKey] = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void CheckTheme(FrameworkElement element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            if (element.RequestedTheme != AppTheme)
            {
                element.RequestedTheme = AppTheme;
            }
        }
    }
}
