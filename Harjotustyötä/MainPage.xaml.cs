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
        private Etana2 etana2;
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
                LocationX = 900,
                LocationY = 500
            };

            etana2 = new Etana2
            {
                LocationXX = 300,
                LocationYY = CanvasHeight - 70
            };


            MyCanvas.Children.Add(etana);
            MyCanvas.Children.Add(etana2);
        }

        private void Timer_Tick(object sender, object e)
        {
            etana.Move();
            etana.UpdateLocation();
            etana2.Move();
            etana2.UpdateLocation();
        }


    }
}
