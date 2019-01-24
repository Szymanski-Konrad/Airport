using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public class AirportService
    {
        public int id { get; set; }
        public int idAirport { get; set; }
        public string job { get; set; }
        public float salary { get; set; }

        public void SetSalary()
        {
            switch (job)
            {
                case "mechanik":
                    salary = 2000;
                    break;
                case "kasjer":
                    salary = 1500;
                    break;
                case "ochroniarz":
                    salary = 1700;
                    break;
                case "sprzatacz":
                    salary = 1400;
                    break;
            }
        }
    }
}
