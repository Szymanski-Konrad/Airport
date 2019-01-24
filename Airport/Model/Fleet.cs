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
        public int planeCondition { get; set; }
        public int capacityGasTank { get; set; }
        public bool isBusy { get; set; }
    }
}
