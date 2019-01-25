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
            newPlane.isService = false;
            newPlane.isBusy = false;
            newPlane.fuel = 100;
            newPlane.capacityGasTank = plane.capacityGasTank;

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
                    transaction.Commit();
                }
            }

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(newAirport);
                    transaction.Commit();
                }
            }

            Warehouse warehouse = new Warehouse();
            warehouse.capacityGasTank = 5000000;
            warehouse.fuelAmount = 1000;
            warehouse.idAirport = airport.id;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    warehouse.idAirport = session.Query<Airport>().Where(x => x.name == newAirport.name).First().id;
                    session.Save(warehouse);
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

        public static void TankFuel(Warehouse warehouse)
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

        public static Warehouse GetWarehouse(int id)
        {
            Warehouse warehouse = new Warehouse();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    warehouse = session.Query<Warehouse>().Where(x => x.idAirport == id).First();
                }
            }

            return warehouse;
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
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (var item in airportMarkets)
                        session.Save(item);
                    transaction.Commit();
                }
            }
        }

        public static void HireAirportWorker(AirportService service)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(service);
                    transaction.Commit();
                }
            }
        }

        public static void FireAirportWorker(AirportService service)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(service);
                    transaction.Commit();
                }
            }
        }

        public static List<AirportService> GetAirportServices(int id)
        {
            List<AirportService> list = new List<AirportService>();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    list = session.Query<AirportService>().Where(x => x.idAirport == id).ToList();
                }
            }

            return list;
        }

        public static List<Service> GetServicesFromAirport(int id)
        {
            List<Service> list = new List<Service>();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    list = session.Query<Service>().Where(x => x.id == id).ToList();
                }
            }

            return list;
        }

        public static bool MakeConnection(Airport start, Airport end)
        {
            List<Connection> list = new List<Connection>();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    list = session.Query<Connection>().ToList();
                }
            }

            foreach (var item in list)
            {
                if (item.idAirportStart == start.id && item.idAirportEnd == end.id)
                {
                    return false;
                }
            }
            Random random = new Random();
            Connection connection = new Connection();
            connection.idAirportStart = start.id;
            connection.idAirportEnd = end.id;
            connection.Name = start.name + " - " + end.name;
            connection.distance = random.Next(300, 3000);

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(connection);
                    transaction.Commit();
                }
            }

            return true;
        }

        public static Connection GetConnection(int start, int end)
        {
            Connection connection = new Connection();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    connection = session.Query<Connection>().Where(x => x.idAirportStart == start && x.idAirportEnd == end).First();
                }
            }

            return connection;
        }

        public static List<Connection> GetConnections()
        {
            List<Connection> list = new List<Connection>();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    list = session.Query<Connection>().ToList();
                }
            }

            return list;
        }

        public static void SaveFlight(Flight flight)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(flight);
                    transaction.Commit();
                }
            }
        }

        public static void UpdateBooking(Booking booking)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(booking);
                    transaction.Commit();
                }
            }
        }

        public static List<Fleet> GetFleetToService()
        {
            List<Fleet> list = new List<Fleet>();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    list = session.Query<Fleet>().Where(x => x.isService == false).ToList();
                }
            }

            return list;
        }

        public static void FleetInService(Fleet fleet)
        {
            fleet.isService = true;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(fleet);
                    transaction.Commit();
                }
            }
        }

        public static void FleetOutService(Fleet fleet)
        {
            fleet.isService = false;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(fleet);
                    transaction.Commit();
                }
            }
        }

        public static void SaveService(Service service)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(service);
                    transaction.Commit();
                }
            }
        }

        public static void RemoveService(Service service)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(service);
                    transaction.Commit();
                }
            }
        }

        public static Fleet GetFleetByID(int id)
        {
            Fleet fleet = new Fleet();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    fleet = session.Query<Fleet>().Where(x => x.id == id).First();
                    transaction.Commit();
                }
            }

            return fleet;
        }
    }
}
