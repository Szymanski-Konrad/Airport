using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHiber.Tables
{
    class Booking
    {
        public int id { get; set; }
        public int idFlight { get; set; }
        public float price { get; set; }
        public int seats { get; set; }
    }
}
