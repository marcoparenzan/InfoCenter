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
    public class WatchScreenSaverViewModel : BaseViewModel<WatchScreenSaverViewModel>
    {
        public WatchScreenSaverViewModel()
        {
            CreateTimer(1, UpdateTime);
            CreateTimer(10, RandomMove);
            UpdateTime();
            RandomMove();
        }

        private void UpdateTime()
        {
            Time = DateTime.Now;
        }

        private void RandomMove()
        {
            var view = Root.Content as WatchScreenSaverPage;
            if (view == null) return;
            view.RandomMove();
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
