using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public class Client
    {
        public int id { get; set; }
        public List<int> idBooking { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool isMale { get; set; }
        public int milesTraveled { get; set; }
        public int age { get; set; }
    }
}
