using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    class Client
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool isMale { get; set; }
        public int milesTraveled { get; set; }
        public int age { get; set; }
    }
}
