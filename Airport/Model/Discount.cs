using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    class Discount
    {
        public int id { get; set; }
        public DateTime dateDeparture { get; set; }
        public DateTime dateArrival { get; set; }
        public float value { get; set; }
    }
}
