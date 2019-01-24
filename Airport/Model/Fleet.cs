using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public class Fleet
    {
        public int id { get; set; }
        public int idPlane { get; set; }
        public string planeCondition { get; set; }
        public string capacityGasTank { get; set; }
    }
}
