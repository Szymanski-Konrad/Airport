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
                brand = "Airbus",
                capacityGasTank = 20000,
                capacityLuggage = 5000,
                capacityPersons = 2000,
                price = 2000,
                range = 5000,
                
            });
            list.Add(new PlaneMarket()
            {
                brand = "Extra",
                capacityGasTank = 5000,
                capacityLuggage = 500,
                capacityPersons = 200,
                price = 6000,
                range = 8000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "Max",
                capacityGasTank = 4000,
                capacityLuggage = 500,
                capacityPersons = 200,
                price = 2000,
                range = 50000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "Airbus",
                capacityGasTank = 4000,
                capacityLuggage = 1000,
                capacityPersons = 250,
                price = 7500,
                range = 7500,

            });

            list.Add(new PlaneMarket()
            {
                brand = "Dreams",
                capacityGasTank = 200000,
                capacityLuggage = 5000,
                capacityPersons = 2000,
                price = 50000,
                range = 100000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "YourPlane",
                capacityGasTank = 2200,
                capacityLuggage = 550,
                capacityPersons = 220,
                price = 5500,
                range = 11000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "YourPlane",
                capacityGasTank = 12000,
                capacityLuggage = 1500,
                capacityPersons = 1200,
                price = 15000,
                range = 110000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "MyPlane",
                capacityGasTank = 22000,
                capacityLuggage = 2500,
                capacityPersons = 2200,
                price = 25000,
                range = 210000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "MyPlane",
                capacityGasTank = 22000,
                capacityLuggage = 2500,
                capacityPersons = 2200,
                price = 25000,
                range = 210000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "Airbus",
                capacityGasTank = 22000,
                capacityLuggage = 2500,
                capacityPersons = 2200,
                price = 25000,
                range = 210000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "Higher",
                capacityGasTank = 22000,
                capacityLuggage = 2500,
                capacityPersons = 2200,
                price = 25000,
                range = 210000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "Higher",
                capacityGasTank = 22000,
                capacityLuggage = 2500,
                capacityPersons = 2200,
                price = 25000,
                range = 210000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "EasyLot",
                capacityGasTank = 22000,
                capacityLuggage = 2500,
                capacityPersons = 2200,
                price = 25000,
                range = 210000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "EasyLot",
                capacityGasTank = 32000,
                capacityLuggage = 3500,
                capacityPersons = 3200,
                price = 35000,
                range = 310000,

            });
            list.Add(new PlaneMarket()
            {
                brand = "Airbus",
                capacityGasTank = 12000,
                capacityLuggage = 6500,
                capacityPersons = 6200,
                price = 65000,
                range = 610000,

            });

            return list;
        }

        public static List<AirportMarket> GetBuyAirportList()
        {
            return new List<AirportMarket>()
            {
                new AirportMarket() { bought = false, name = "Warszawa" },
                new AirportMarket() { bought = false, name = "Kolno" },
                new AirportMarket() { bought = false, name = "Bialystok" },
                new AirportMarket() { bought = false, name = "Wizna" },
                new AirportMarket() { bought = false, name = "Gdansk" },
                new AirportMarket() { bought = false, name = "Krakow" },
                new AirportMarket() { bought = false, name = "Kielce" },
                new AirportMarket() { bought = false, name = "Poznan" },
                new AirportMarket() { bought = false, name = "Szczecin" },
            };
        }
    }
}
