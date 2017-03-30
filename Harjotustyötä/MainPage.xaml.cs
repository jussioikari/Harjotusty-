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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Harjotustyötä
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Etana etana;
        // game loop timer
        private DispatcherTimer timer;
        private double CanvasWidth;
        private double CanvasHeight;
        public MainPage()
        {
            this.InitializeComponent();

            // game loop 
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Start();

            CanvasWidth = MyCanvas.Width;
            CanvasHeight = MyCanvas.Height;

            etana = new Etana
            {
                LocationX = CanvasWidth - 800,
                LocationY = CanvasHeight / 100
            };
                
            MyCanvas.Children.Add(etana);
        }

        private void Timer_Tick(object sender, object e)
        {
            etana.Move();
            etana.UpdateLocation();
        }


    }
}
