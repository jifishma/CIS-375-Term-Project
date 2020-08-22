using Hotel_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hotel_Management_System
{
    static class ControlFactory
    {
        public static Login loginControl = new Login();
        public static NavigationFrame frameControl = new NavigationFrame();

        public static ParentControl mainControl { get; set; }
        public static ParentControl subControl { get => frameControl.MainControl; }

        public static Entities.Entities HotelDB = new Entities.Entities();
    }
}
