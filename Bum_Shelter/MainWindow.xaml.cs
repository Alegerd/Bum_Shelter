using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bum_Shelter.Controls;

namespace Bum_Shelter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool DoorBtnIsResised { get; set; }
        private Point InstantMainDoorBtnSize { get; set; }
        private Thickness InstantMainDoorBtnMargin { get; set; }
        private List<Cloud> Clouds = new List<Cloud>();
        private House House { get; set; } = new House();

        public MainWindow()
        {
            InitializeComponent();
            InstantMainDoorBtnSize = new Point(DoorBtn.Width, DoorBtn.Height);
            mainThemeSound.Play();
            InstantMainDoorBtnMargin = DoorBtn.Margin;
            MainDoor.doorState = MainDoor.DoorState.Closed;
            MakeClouds();
            foreach (Cloud cloud in Clouds) { cloud.AnimateVertical(); }
            MakeEnteringRoom();
        }

        private void MakeClouds()
        {
            Clouds.Add(Cloud1);
            Clouds.Add(Cloud2);
            Clouds.Add(Cloud3);
            Cloud3.AnimateHorisontal();
        }

        private void MakeEnteringRoom()
        {
            Enter er = new Enter();
            Grid.SetColumn(er, 1);
            Grid.SetRow(er, 1);
            er.RealMargin = new Thickness(600, 370, 0, 0);
            House.Rooms[1, 1] = er;
            MainGrid.Children.Add(er);
        }

        private void CreateHuman()
        {
            Human newHuman = new Human();
            newHuman.Margin = new Thickness(0, 370, 0, 0);
            MainCanvas.Children.Add(newHuman);
        }

        private void DoorBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateHuman();
            DoorBtn.Width *= 0.9;
            DoorBtn.Height *= 0.9;
            DoorBtn.Margin = new Thickness(DoorBtn.Margin.Left + 5, DoorBtn.Margin.Top + 5, 0, 0);
        }

        private void DoorBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (MainDoor.DoorAnimationCompleted)
            {
                MainDoor.DoorNetOff();
                doorOpeningSound.Position = new TimeSpan(0, 0, 0, 0);
                doorOpeningSound.Play();
                if (MainDoor.doorState == Controls.MainDoor.DoorState.Closed)
                {
                    Claw.Up();
                    //Gear.Rotate(1);
                    MainDoor.Open();
                }
                else if (MainDoor.doorState == Controls.MainDoor.DoorState.Opened)
                {
                    Claw.Down();
                    //Gear.Rotate(-1);
                    MainDoor.Close();
                }
            }


            DoorBtn_MouseLeave(null, null);
        }

        private void DoorBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (MainDoor.DoorAnimationCompleted)
            {
                MainDoor.DoorNetOff();
            }
            DoorBtn.Width = InstantMainDoorBtnSize.X;
            DoorBtn.Height = InstantMainDoorBtnSize.Y;
            DoorBtn.Margin = InstantMainDoorBtnMargin;
        }

        private void DoorBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (MainDoor.DoorAnimationCompleted)
            {
                MainDoor.DoorNetOn();
            }
            DoorBtn.Margin = new Thickness(DoorBtn.Margin.Left + 5, DoorBtn.Margin.Top + 5, 0, 0);
            DoorBtn.Width *= 0.9;
            DoorBtn.Height *= 0.9;
        }

        private void mainThemeSound_MediaEnded(object sender, RoutedEventArgs e)
        {
            mainThemeSound.Position = TimeSpan.Zero;
            mainThemeSound.Play();
        }

        private void MainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(MainCanvas);
            TryToMakeRoom(p);
            //if (p.X < 527 && p.Y > 509)
            //{
            //    Enter er = new Enter();
            //    er.RealMargin = new Thickness(0 + 100, 600 + 70, 0, 0);
            //    Grid.SetColumn(er, 0);
            //    Grid.SetRow(er, 2);
            //    MainGrid.Children.Add(er);
            //}
            //if (p.X > 527 && p.X < 1054 && p.Y > 509)
            //{
            //    Enter er = new Enter();
            //    er.RealMargin = new Thickness(527 + 100, 600 + 70, 0, 0);
            //    Grid.SetColumn(er, 1);
            //    Grid.SetRow(er, 2);
            //    MainGrid.Children.Add(er);
            //}
        }

        private void TryToMakeRoom(Point p)
        {
            int Y;
            Y = (int)Math.Floor(p.Y / 300);

            int X;
            X = (p.X < 527) ? 0 : (p.X < 1054) ? 1 : 2;

            if (Y != 0 && Y != 1)
            {
                if (X == 0 || X == 1)
                {
                    if (House.Rooms[X, Y] == null)
                    {
                        House.Rooms[X, Y] = MakeNewRoom(new Point(X, Y));
                    }
                }
            }
        }

        private Room MakeNewRoom(Point p)
        {
            //Enter newRoom = new Enter();
            Room newRoom = null;
            if((bool)radioButtonEnergy.IsChecked) 
            {
                newRoom = new PowerRoom();
            }
            else if ((bool)radioButtonWater.IsChecked)
            {
                newRoom = new WaterRoom();
            }

            if (newRoom != null)
            {
                Grid.SetColumn(newRoom, (int)p.X);
                Grid.SetRow(newRoom, (int)p.Y);
                newRoom.RealMargin = new Thickness(p.X * 527 + 100, p.Y * 300 + 70, 0, 0);
                MainGrid.Children.Add(newRoom);
            }
                return newRoom;
        }
    }

}
