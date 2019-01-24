using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Airport.Model;

namespace Airport
{
    public static class CustomData
    {
        public static void InsertFleet()
        {

        }

        public static void InsertAirports()
        {

        }

        public static void GenerateWorkers()
        {

        }

        public static List<PlaneMarket> GetBuyList()
        {
            var list = new List<PlaneMarket>();
            list.Add(new PlaneMarket()
            {
                brand = "LOT",
                capacityGasTank = 2000,
                capacityLuggage = 500,
                capacityPersons = 200,
                id = 1,
                isSecondHand = false,
                price = 5000,
                range = 10000,
                
            });
            list.Add(new PlaneMarket()
            {
                brand = "TOL",
                capacityGasTank = 2000,
                capacityLuggage = 500,
                capacityPersons = 200,
                id = 4,
                isSecondHand = false,
                price = 5000,
                range = 10000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "LAT",
                capacityGasTank = 2000,
                capacityLuggage = 500,
                capacityPersons = 200,
                id = 3,
                isSecondHand = false,
                price = 5000,
                range = 10000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "LOT",
                capacityGasTank = 2000,
                capacityLuggage = 500,
                capacityPersons = 200,
                id = 2,
                isSecondHand = false,
                price = 5000,
                range = 10000,

            });

            return list;
        }
    }
}
