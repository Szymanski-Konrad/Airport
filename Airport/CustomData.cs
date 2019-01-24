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
                price = 5000,
                range = 10000,

            });

            return list;
        }

        public static List<AirportMarket> GetBuyAirportList()
        {
            return new List<AirportMarket>()
            {
                new AirportMarket()
                {
                    bought = false,
                    id = 1,
                    name = "Warszawa"
                },
                new AirportMarket()
                {
                    bought = false,
                    id = 2,
                    name = "Kolno"
                },
                new AirportMarket()
                {
                    bought = false,
                    id = 3,
                    name = "Bialystok"
                },
                new AirportMarket()
                {
                    bought = false,
                    id = 4,
                    name = "Gdansk"
                },
            };
        }
    }
}
