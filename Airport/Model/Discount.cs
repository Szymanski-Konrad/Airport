using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public class Discount
    {
        public int id { get; set; }
        public int idConnection { get; set; }
        public float value { get; set; }
    }
}
