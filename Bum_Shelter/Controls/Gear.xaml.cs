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
using System.Windows.Threading;

namespace Bum_Shelter.Controls
{
    /// <summary>
    /// Логика взаимодействия для Gear.xaml
    /// </summary>
    public partial class Gear : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer mainTimer = new DispatcherTimer();
        RotateTransform alpha = new RotateTransform();
        int roateSide;
        //Transform instatceRT;

        public Gear()
        {
            InitializeComponent();
            alpha.CenterX = 42;
            alpha.CenterY = 42;
            //instatceRT = RenderTransform;
            mainTimer.Interval = TimeSpan.FromSeconds(6.5);
            mainTimer.Tick += mainTimer_Tick;
        }

        public void Rotate(int side)
        {
            roateSide = side;
            mainTimer.Start();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void StopRotate()
        {
            timer.Stop();
            //RenderTransform = instatceRT;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            alpha.Angle += roateSide*5;
            RenderTransform = alpha;
        }
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            mainTimer.Stop();
            StopRotate();
        }
    }
}
