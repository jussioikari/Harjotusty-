﻿using System;
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
    public sealed partial class Etana : UserControl
    {
        // location
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        private readonly double Speed = 4.0;
        int MinLocationY = 655;


       public Etana()
        {
            this.InitializeComponent();
        }

        public void Move()
        {
            if (LocationY < MinLocationY)

                LocationY += 1 + Speed * 1;

            else if (LocationY > 654)
                LocationY -= 1 + Speed * 50;
            
        }
        public void UpdateLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
    }

}
        

