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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Platform
{
    public sealed partial class Etana : UserControl
    {
        public double StartLocationX { get; set; }
        public double StartLocationY { get; set; }
        private double Speed = 3.0;
        int EndLocationYY = 550;
        public Etana()
        {
            this.InitializeComponent();
        }

        public void MoveDown()
        {
            StartLocationY += Speed;

            if (StartLocationY >= EndLocationYY || StartLocationY <= 329)
            {
                Speed = (-1) * Speed;
            }
        }

        /*public void MoveRight()
        {
            StartLocationX += Speed;

            if (StartLocationX >= EndLocationXX || StartLocationX <= 300)
            {
                Speed = (-1) * Speed;
            }

        }*/

        public void UpdateLocation()
        {
            SetValue(Canvas.LeftProperty, StartLocationX);
            SetValue(Canvas.TopProperty, StartLocationY);
        }
    }
}
