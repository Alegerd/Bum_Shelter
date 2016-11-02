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
    /// Логика взаимодействия для Cloud.xaml
    /// </summary>
    public partial class Cloud : UserControl
    { 

        public Cloud()
        {
            InitializeComponent();
        }

        public void AnimateVertical()
        {
            ThicknessAnimation cloudAnim = new ThicknessAnimation();
            cloudAnim.From = Margin;
            cloudAnim.To = new Thickness(Margin.Left, Margin.Top - 20, 0, 0);
            cloudAnim.Duration = TimeSpan.FromSeconds(2);
            cloudAnim.AutoReverse = true;
            cloudAnim.RepeatBehavior = RepeatBehavior.Forever;
            BeginAnimation(MarginProperty, cloudAnim);
        }

        public void AnimateHorisontal()
        {
            ThicknessAnimation cloudAnim = new ThicknessAnimation();
            cloudAnim.From = Margin;
            cloudAnim.To = new Thickness(Margin.Left-1280, Margin.Top, 0, 0);
            cloudAnim.Duration = TimeSpan.FromSeconds(30);
            cloudAnim.AutoReverse = true;
            cloudAnim.RepeatBehavior = RepeatBehavior.Forever;
            BeginAnimation(MarginProperty, cloudAnim);
        }

    }
}
