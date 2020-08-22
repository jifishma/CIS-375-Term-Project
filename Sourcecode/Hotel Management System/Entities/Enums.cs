using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System.Entities
{
    class Enums
    {
        public enum Package
        {
            Room = 1,
            Event
        }

        public enum Availability
        {
            Available = 1,
            Reserved,
            Maintenance
        }
    }
}
