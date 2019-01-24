using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public static class FirmNHiberControl
    {
        public static void BuyPlane(PlaneMarket plane)
        {
            Fleet newPlane = new Fleet();
            newPlane.capacityGasTank = plane.capacityGasTank;
            newPlane.idPlane = plane.id;
            newPlane.planeCondition = 100;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(newPlane);
                    transaction.Commit();
                }
            }
        }

        public static void SoldPlane(Fleet plane)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(plane);
                    transaction.Commit();
                }
            }
        }

        public static void EditPlane(Fleet plane)
        {

        }

        public static void BuyAirport(AirportMarket airport)
        {
            Airport newAirport = new Airport();
            newAirport.name = airport.name;

            airport.bought = true;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(airport);
                    session.Save(newAirport);
                    transaction.Commit();
                }
            }
        }

        public static void BuyFuel(Warehouse warehouse)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(warehouse);
                    transaction.Commit();
                }
             }
        }

        public static List<Fleet> GetFleets()
        {
            List<Fleet> list = new List<Fleet>();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    list = session.Query<Fleet>().ToList();
                }
            }

            return list;
        }

        public static List<AirportMarket> GetAirportMarkets()
        {
            List<AirportMarket> list = new List<AirportMarket>();
            
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    list = session.Query<AirportMarket>().Where(x => x.bought == false).ToList();
                }
            }

            return list;
        }

        public static List<Model.Airport> GetAirports()
        {
            List<Model.Airport> list = new List<Airport>();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    list = session.Query<Airport>().ToList();
                }
            }

            return list;
        }

        public static void SaveAirportMarkets(List<AirportMarket> airportMarkets)
        {
            using (ISession session = Session.OpenSession())
            {
                using  (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (var item in airportMarkets)
                        session.Save(item);
                    transaction.Commit();
                }
            }
        }
    }
}
