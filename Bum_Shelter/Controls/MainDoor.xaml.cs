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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bum_Shelter.Controls
{
    /// <summary>
    /// Логика взаимодействия для MainDoor.xaml
    /// </summary>
    public partial class MainDoor : UserControl
    {
        public enum DoorState { Opened, Closed }
        public DoorState doorState;
        public bool DoorAnimationCompleted { get; set; }

        public MainDoor()
        {
            InitializeComponent();
            DoorAnimationCompleted = true;
        }

        public void Open()
        {
            ThicknessAnimation openAnimation = new ThicknessAnimation();
            openAnimation.From = Margin;
            openAnimation.To = new Thickness(Margin.Left, Margin.Top-150,0,0);
            openAnimation.Duration = TimeSpan.FromSeconds(6.5);
            openAnimation.Completed += Opening_Completed;
            DoorAnimationCompleted = false;
            BeginAnimation(MarginProperty, openAnimation);
            
        }
        public void Close()
        {
            ThicknessAnimation closeAnimation = new ThicknessAnimation();
            closeAnimation.From = Margin;
            closeAnimation.To = new Thickness(Margin.Left, Margin.Top + 150, 0, 0);
            closeAnimation.Duration = TimeSpan.FromSeconds(6.5);
            closeAnimation.Completed += Closing_Completed;
            DoorAnimationCompleted = false;
            BeginAnimation(MarginProperty, closeAnimation);
        }

        private void Opening_Completed(object sender, EventArgs e)
        {
            doorState = DoorState.Opened;
            DoorAnimationCompleted = true;
        }

        private void Closing_Completed(object sender, EventArgs e)
        {
            doorState = DoorState.Closed;
            DoorAnimationCompleted = true;
        }

        public void DoorNetOn()
        {
            Net.Visibility = Visibility.Visible;
            DoorImg.Opacity = 0.5;
        }

        public void DoorNetOff()
        {
            Net.Visibility = Visibility.Hidden;
            DoorImg.Opacity = 1;
        }

    }
}
