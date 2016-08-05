using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace InfoCenter.Clients.UWP.ViewModels
{
    public abstract class BaseViewModel<TViewModel> : INotifyPropertyChanged
        where TViewModel: BaseViewModel<TViewModel>
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly Frame Root = Window.Current.Content as Frame;

        protected bool NavigateTo<T, T1>(T1 args)
        {
            
            return Root.Navigate(typeof(T), args);
        }

        protected bool NavigateTo<T>()
        {
            return Root.Navigate(typeof(T));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected DispatcherTimer CreateTimer(int seconds, Action callback)
        {
            var timer = new DispatcherTimer();
            timer.Tick += (s, e) => {
                callback();
            };
            timer.Interval = new TimeSpan(0, 0, seconds);

            timer.Start();

            return timer;
        }

        protected async Task<TViewModel> RunAsync(Action callback)
        {
            await Root.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                callback();
            });
            return (TViewModel) this;
        }
    }
}
