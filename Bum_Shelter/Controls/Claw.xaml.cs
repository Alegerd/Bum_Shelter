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
    /// Логика взаимодействия для Claw.xaml
    /// </summary>
    public partial class Claw : UserControl
    {
        public Claw()
        {
            InitializeComponent();
        }
        public void Up()
        {
            ThicknessAnimation openAnimation = new ThicknessAnimation();
            openAnimation.From = Margin;
            openAnimation.To = new Thickness(Margin.Left, Margin.Top - 150, 0, 0);
            openAnimation.Duration = TimeSpan.FromSeconds(6.5);
            BeginAnimation(MarginProperty, openAnimation);
        }
        public void Down()
        {
            ThicknessAnimation closeAnimation = new ThicknessAnimation();
            closeAnimation.From = Margin;
            closeAnimation.To = new Thickness(Margin.Left, Margin.Top + 150, 0, 0);
            closeAnimation.Duration = TimeSpan.FromSeconds(6.5);
            BeginAnimation(MarginProperty, closeAnimation);
        }
    }
}
