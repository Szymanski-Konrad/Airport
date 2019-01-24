using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public class Connection
    {
        public int id { get; set; }
        public int idAirportStart { get; set; }
        public int idAirportEnd { get; set; }
        public string Name { get; set; }
        public int distance { get; set; }


    }
}
