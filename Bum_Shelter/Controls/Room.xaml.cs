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
            humansInRoomLbl.Content = HumansInRoom.Count();
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            AcceptHumanEntering();
        }

        public void AcceptHumanEntering()
        {
            if (Constants.choosenHuman != null)
            {
                Constants.choosenHuman.distanation = new Thickness(RealMargin.Left + Constants.rnd.Next(0, 300), RealMargin.Top, 0, 0);
                Constants.choosenHuman.Move();
                Constants.choosenHuman.humanState = Human.HumanState.isWalking;

                if (!HumansInRoom.Contains(Constants.choosenHuman))
                {
                    HumansInRoom.Add(Constants.choosenHuman);
                }

                humansInRoomLbl.Content = HumansInRoom.Count();
                Constants.choosenHuman = null;//человек больше не в фокусе
            }
        }

        public void AcceptHumanLiving(Human human)
        {
            HumansInRoom.Remove(human);
            humansInRoomLbl.Content = HumansInRoom.Count();
        }
    }
}
