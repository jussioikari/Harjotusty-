using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Platform
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {

        private Character character;

        // game loop timer
        private DispatcherTimer timer;

        // canvas width and height
        private double CanvasWidth;
        private double CanvasHeight;

        // Which keys are pressed
        private bool LeftPressed;
        private bool RightPressed;
        private bool UpPressed;

        // Enemies
        private Etana etana;
        private Fly fly;


        // Props
        private Platform platform;
        private Tree tree;
        private Flower flower;

        float positionX, positionY;     // Position of the character
        float velocityX, velocityY;     // Velocity of the character
        float gravity = 0.5f;           // How strong is gravity
        
        // Audio
        private MediaElement mediaElement;


        public GamePage()
        {
            this.InitializeComponent();


            // key listeners
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;


            // get canvas width and height
            CanvasWidth = MyCanvas.Width;
            CanvasHeight = MyCanvas.Height;

            // Add character
            character = new Character
            {
                LocationX = CanvasWidth - 1280,
                LocationY = CanvasHeight - 195
            };
            

            // game loop 
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Start();

            // init audio
            InitAudio();

            // Add etana
            etana = new Etana
            {
                StartLocationX = 300,
                StartLocationY = 330
            };

            // Add fly
            fly = new Fly
            {
                StartLocationXX = 900,
                StartLocationYY = 360
            };

            // Add platform
            platform = new Platform
            {
                LocationX = CanvasWidth -1330,
                LocationY = CanvasHeight -130
            };

            // Add tree
            tree = new Tree
            {
                LocationX = CanvasWidth - 1200,
                LocationY = CanvasHeight - 750
            };

            flower = new Flower
            {
                LocationX = CanvasWidth - 165,
                LocationY = CanvasHeight - 190
            };

            // Draw everyting on Canvas
            MyCanvas.Children.Add(tree);
            MyCanvas.Children.Add(flower);
            MyCanvas.Children.Add(character);
            MyCanvas.Children.Add(etana);
            MyCanvas.Children.Add(fly);
            MyCanvas.Children.Add(platform);
            
        }





        /// <summary>
        /// Game loop.
        /// </summary>
        private void Timer_Tick(object sender, object e)
        {
            // Move 
            if (LeftPressed) { character.LocationX -= 10; }
            if (RightPressed) { character.LocationX += 10; }

            // Update
            character.UpdateLocation();

            // Update props
            tree.UpdateLocation();
            platform.UpdateLocation();
            flower.UpdateLocation();

            // Update etana

            etana.MoveDown();
            etana.UpdateLocation();

            // Update fly
            fly.MoveDown();
            fly.UpdateLocation();
            
            

            // collision
            CheckCollision();

            

        }

        private async void InitAudio()
        {
            // audios
            mediaElement = new MediaElement();
            StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            StorageFile file = await folder.GetFileAsync("gameover.mp3");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            mediaElement.AutoPlay = false;
            mediaElement.SetSource(stream, file.ContentType);
        }

        private void CheckCollision()
        {
            // get butterfly and flower rects
            Rect r1 = new Rect(character.LocationX, character.LocationY, character.ActualWidth, character.ActualHeight);
            Rect r2 = new Rect(etana.StartLocationX, etana.StartLocationY, etana.ActualWidth, etana.ActualHeight);
            
            // does thoes intersects
            r1.Intersect(r2);
            // yes if not empty
            if (!r1.IsEmpty)
            {
                Frame.Navigate(typeof(BlankPage1));
                // play audio
                mediaElement.Play();
            }

            r1 = new Rect(character.LocationX, character.LocationY, character.ActualWidth, character.ActualHeight);
            Rect r3 = new Rect(fly.StartLocationXX, fly.StartLocationYY, fly.ActualWidth, fly.ActualHeight);
            r1.Intersect(r3);
            // yes if not empty
            if (!r1.IsEmpty)
            {
                Frame.Navigate(typeof(BlankPage1));
                // play audio
                mediaElement.Play();
            }

            r1 = new Rect(character.LocationX, character.LocationY, character.ActualWidth, character.ActualHeight);
            Rect r4 = new Rect(flower.LocationX, flower.LocationY, flower.ActualWidth, flower.ActualHeight);
            r1.Intersect(r4);
            // yes if not empty
            if (!r1.IsEmpty)
            {
                Frame.Navigate(typeof(GamePage2));
            }
        }

                void Update(float time)
        {
            positionX += velocityX * time;      // Apply horizontal velocity to X position
            positionY += velocityY * time;      // Apply vertical velocity to X position
            velocityY += gravity * time;        // Apply gravity to vertical velocity
        }

        void OnJumpKeyPressed()
        {
            velocityY = -12.0f;   // Give a vertical boost to the players velocity to start jump
        }

        void OnJumpKeyReleased()
        {
            if (velocityY < -6.0f)       // If character is still ascending in the jump
                velocityY = -6.0f;      // Limit the speed of ascent
        }


        /// <summary>
        /// Check if some keys are released.
        /// </summary>
        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:
                    LeftPressed = false;
                    break;
                case VirtualKey.Right:
                    RightPressed = false;
                    break;
                case VirtualKey.Up:
                    UpPressed = false;
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Check if some keys are pressed.
        /// </summary>
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Left:
                    LeftPressed = true;
                    break;
                case VirtualKey.Right:
                    RightPressed = true;
                    break;
                case VirtualKey.Up:
                    UpPressed = true;
                    break;
                default:
                    break;
            }
        }

    }
}   

