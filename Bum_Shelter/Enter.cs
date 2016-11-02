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
    class Enter : Room
    {
        public Enter()
        {
            RoomState = RoomKind.Entering;
            RoomImage.Source = new BitmapImage(new Uri("../Textures/EnteringRoom.png", UriKind.Relative));            
        }
    }
}
