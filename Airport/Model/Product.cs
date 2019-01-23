using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Discounted { get; set; }

        public string Say()
        {
            if (Discounted)
                return "Jest na przecenie " + Name;
            else return "Nie jest na przecenie " + Name;
        }
    }
}
