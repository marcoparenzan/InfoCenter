using InfoCenter.Clients.UWP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace InfoCenter.Clients.UWP.ViewModels
{
    public class DashboardViewModel : BaseViewModel<DashboardViewModel>
    {
        private DispatcherTimer _screenSaverTimer;

        public DashboardViewModel()
        {
            _screenSaverTimer = CreateTimer(1, () =>
            {
                _screenSaverTimer.Stop();
                NavigateTo<WatchScreenSaverPage>();
            });
        }

        public void ResetScreenSaver()
        {
            _screenSaverTimer.Stop();
            _screenSaverTimer.Start();
        }

        private DateTime _time;

        public DateTime Time
        {
            get
            {
                return _time;
            }

            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }
    }
}
