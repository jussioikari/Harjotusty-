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
        private Fly fly;
        private Platform platform;
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
                StartLocationX = 300,
                StartLocationY = CanvasHeight - 216
            };

           fly = new Fly
            {
               StartLocationXX = 900,
               StartLocationYY = 500
           };

            platform = new Platform
            {
                LocationX = 300,
                LocationY = CanvasHeight - 170
            };


            MyCanvas.Children.Add(etana);
            MyCanvas.Children.Add(fly);
            MyCanvas.Children.Add(platform);
        }

        private void Timer_Tick(object sender, object e)
        {
            etana.MoveRight();
            etana.UpdateLocation();
            fly.MoveDown();
            fly.UpdateLocation();
            platform.UpdateLocation();
        }


    }
}
