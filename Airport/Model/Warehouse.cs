using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    class Warehouse
    {
        public int id { get; set; }
        public int idAirport { get; set; }
        public int fuelAmount { get; set; }
        public int capacityGasTank { get; set; }
    }
}
