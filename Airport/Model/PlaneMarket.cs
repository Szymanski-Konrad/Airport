﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public class PlaneMarket
    {
        public int id { get; set; }
        public string brand { get; set; }
        public int price { get; set; }
        public int capacityPersons { get; set; }
        public int capacityLuggage { get; set; }
        public int capacityGasTank { get; set; }
        public int range { get; set; }
    }
}
