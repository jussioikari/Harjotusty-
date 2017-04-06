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

namespace Harjotustyötä
{
    public sealed partial class Etana2 : UserControl
    {
        public double LocationXX { get; set; }
        public double LocationYY { get; set; }
        private readonly double Speed = 3.0;
        int MaxLocationX = 500;
        public Etana2()
        {
            this.InitializeComponent();
        }
        public void Move()
        {
            if (LocationXX < MaxLocationX)

                LocationXX += 1 + Speed * 1;

            else
                LocationXX -= 1 + Speed * 90;

        }
        public void UpdateLocation()
        {
            SetValue(Canvas.LeftProperty, LocationXX);
            SetValue(Canvas.TopProperty, LocationYY);
        }
    }
}
