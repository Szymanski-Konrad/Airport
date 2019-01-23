using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHiber.Tables
{
    class Service
    {
        public int id { get; set; }
        public int idAirport { get; set; }
        public int idPlane { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
    }
}
