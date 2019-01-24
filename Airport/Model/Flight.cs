using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    class Flight
    {
        public int id { get; set; }
        public int idConnection { get; set; }
        public int idPlane { get; set; }
        public DateTime dateDeparture { get; set; }
        public DateTime dateArrival { get; set; }
    }
}
