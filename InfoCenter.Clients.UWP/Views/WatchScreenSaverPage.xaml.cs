using InfoCenter.Clients.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InfoCenter.Clients.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WatchScreenSaverPage : Page
    {
        public WatchScreenSaverPage()
        {
            this.DataContext = new WatchScreenSaverViewModel();
            this.InitializeComponent();
        }

        private Random random = new Random();

        public void RandomMove()
        {
            Canvas.SetLeft(CurrentWatch,  random.Next(0, (int)(ActualWidth - CurrentWatch.ActualWidth)));
            Canvas.SetTop(CurrentWatch, random.Next(0, (int)(ActualHeight - CurrentWatch.ActualHeight)));
        }
    }
}
