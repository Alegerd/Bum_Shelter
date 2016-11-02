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

namespace Bum_Shelter.Controls
{
    /// <summary>
    /// Логика взаимодействия для Room.xaml
    /// </summary>
    public partial class Room : UserControl
    {
        public Thickness RealMargin;
        public List<Human> HumansInRoom = new List<Human>();

        public enum RoomKind
        {
            Entering,
            Power,
            Water,
            GunHouse
        }
        public RoomKind RoomState { get; set; }

        public Room()
        {
            InitializeComponent();
            MouseUp += OnMouseUp;           
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Constants.choosenHuman != null)
            {
                HumansInRoom.Add(Constants.choosenHuman);
                Constants.choosenHuman.distanation = new Thickness(RealMargin.Left + Constants.rnd.Next(0, 300) ,RealMargin.Top,0,0);
                Constants.choosenHuman.Move();
                Constants.choosenHuman.humanState = Human.HumanState.isWalking;
                Constants.choosenHuman = null;
            }
        }
    }
}
