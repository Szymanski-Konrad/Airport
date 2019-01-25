using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public class Booking
    {
        public int id { get; set; }
        public int idFlight { get; set; }
        public int idClient { get; set; }
        public float price { get; set; }
        public int seats { get; set; }

        public override string ToString()
        {

            return $"Price: {price} $, seats: {seats}, {NHiberControl.LoadFlightsToList().Single(x => x.id == idFlight).ToString()} ";
        }
    }
}
