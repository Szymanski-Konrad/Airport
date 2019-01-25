using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Airport.Model;
using System.Diagnostics;

namespace Airport.Model
{
    public static class NHiberControl
    {
        public static void RefreshTables()
        {
            using (ISession session = Session.OpenSession())
            {

            }
        }

        #region Insert Methods
        public static void InsertFirm()
        {
            Firm firm = new Firm();
            firm.account = 10000;
            firm.name = "Firma na 5";

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(firm);
                    transaction.Commit();
                }
            }
        }

        public static void InsertClient(string name, string surname, bool isMale, int milesTraveled, int age)
        {
            Debug.Print($"NHiberControl method InsertClient called.");
            Client client = new Client();
            client.Name = name;
            client.Surname = surname;
            client.isMale = isMale;
            client.milesTraveled = milesTraveled;
            client.age = age;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(client);
                    transaction.Commit();
                }
            }
            Debug.Print("Insert client to database.");
        }

        public static void InsertConnection(int idAirportStart, int idAirportEnd, int distance)
        {
            Debug.Print($"NHiberControl method InsertConnection called.");
            Connection connection=new Connection();
            connection.idAirportStart = idAirportStart;
            connection.idAirportEnd = idAirportEnd;
            connection.Name = $"{LoadAirportsToList().Single(x => x.id == connection.idAirportStart).name} - {LoadAirportsToList().Single(x => x.id == connection.idAirportEnd).name}";
            connection.distance = 100;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(connection);
                    transaction.Commit();
                }
            }
            Debug.Print("Insert connection to database.");
        }

        public static void InsertBooking(int idFlight, int idClient)
        {
            Debug.Print($"NHiberControl method InsertBooking called.");
            Booking booking = new Booking();
            booking.idFlight = idFlight;
            booking.idClient = idClient;
            booking.price = 125;
            booking.seats = 1;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(booking);
                    transaction.Commit();
                }
            }
            Debug.Print("Insert booking to database.");
        }
        #endregion Insert Methods

        #region Load Methods
        public static List<Airport> LoadAirportsToList()
        {
            Debug.Print($"NHiberControl method LoadAirportsToList called.");
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Airport order by name asc");
                if (query != null)
                {
                    IList<Airport> airports = query.List<Airport>();
                    Debug.Print("Connections found: " + airports.Count.ToString());
                    return (List<Airport>)airports;
                }
                else
                {
                    Debug.Print("Query is null.");
                    return new List<Airport>();
                }
            }
        }

        public static List<Booking> LoadBookingsToList()
        {
            Debug.Print($"NHiberControl method LoadBookingsToList called.");
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Booking order by id asc");
                if (query != null)
                {
                    IList<Booking> bookings = query.List<Booking>();
                    Debug.Print("Bookings found: " + bookings.Count.ToString());
                    return (List<Booking>)bookings;
                }
                else
                {
                    Debug.Print("Query is null.");
                    return new List<Booking>();
                }
            }
        }

        public static void LoadClients()
        {
            Debug.Print($"NHiberControl method LoadClients called.");
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Client order by Name asc");
                if (query != null)
                {
                    IList<Client> clients = query.List<Client>();
                    Debug.Print("znalezieni klienci: " + clients.Count.ToString());
                    foreach (Client client in clients)
                    {
                        Debug.Print(client.Surname + " " + client.Name);
                    }
                }
                else
                {
                    Debug.Print("Query is null.");
                }
            }
        }

        public static List<Client> LoadClientsToList()
        {
            Debug.Print($"NHiberControl method LoadClientsToList called.");
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Client order by Name asc");
                if (query != null)
                {
                    IList<Client> clients = query.List<Client>();
                    Debug.Print("Clients found: " + clients.Count.ToString());
                    return (List<Client>)clients;
                }
                else
                {
                    Debug.Print("Query is null.");
                    return new List<Client>();
                }
            }
        }

        public static List<Connection> LoadConnectionsToList()
        {
            Debug.Print($"NHiberControl method LoadConnectionsToList called.");
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Connection order by id asc");
                if (query != null)
                {
                    IList<Connection> flights = query.List<Connection>();
                    Debug.Print("Connections found: " + flights.Count.ToString());
                    return (List<Connection>)flights;
                }
                else
                {
                    Debug.Print("Query is null.");
                    return new List<Connection>();
                }
            }
        }

        public static List<Fleet> LoadFleetToList()
        {
            Debug.Print($"NHiberControl method LoadFleetToList called.");
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Fleet order by idPlane asc");
                if (query != null)
                {
                    IList<Fleet> fleet = query.List<Fleet>();
                    Debug.Print("Bookings found: " + fleet.Count.ToString());
                    return (List<Fleet>)fleet;
                }
                else
                {
                    Debug.Print("Query is null.");
                    return new List<Fleet>();
                }
            }
        }

        public static List<Flight> LoadFlightsToList()
        {
            Debug.Print($"NHiberControl method LoadFlightsToList called.");
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Flight order by id asc");
                if (query != null)
                {
                    IList<Flight> flights = query.List<Flight>();
                    Debug.Print("Flights found: " + flights.Count.ToString());
                    return (List<Flight>)flights;
                }
                else
                {
                    Debug.Print("Query is null.");
                    return new List<Flight>();
                }
            }
        }

        public static void LoadGames()
        {
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Product order by Name asc");
                IList<Product> foundGames = query.List<Product>();
                MessageBox.Show("znalezione gry:" + foundGames.Count.ToString());
                foreach (Product game in foundGames)
                {
                    MessageBox.Show(game.Say());
                }
            }
        }
        #endregion Load Methods

        #region Save Methods
        public static void SaveGame()
        {
            //Product product = new Product();
            //product.Category = "Nowy";
            //product.Discounted = true;
            //product.Name = "Produkt";

            Firm product = new Firm();
            product.id = 0;
            product.account = 100;
            product.name = "Dupa";

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(product);
                    transaction.Commit();
                }

                MessageBox.Show("Saved product to database");
            }
        }

        public static void SaveAirport(string name)
        {
            Debug.Print($"NHiberControl method SaveAirport called.");
            Airport airport = new Airport();
            airport.name = name;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(airport);
                    transaction.Commit();
                    Debug.Print("Saved airport to database.");
                }
            }
        }

        public static void SaveBooking()
        {
            Debug.Print($"NHiberControl method SaveBooking called.");
            Booking booking = new Booking();
            booking.idFlight = 1;
            booking.idClient = 1;
            booking.price = 240;
            booking.seats = 2;


            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(booking);
                    transaction.Commit();
                    Debug.Print("Saved booking to database.");
                }
            }
        }

        public static void SaveClient()
        {
            Debug.Print($"NHiberControl method SaveClient called.");
            Client client = new Client();
            client.Name = "Joy";
            client.Surname = "En";
            client.isMale = false;
            client.milesTraveled = 0;
            client.age = 18;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(client);
                    transaction.Commit();
                    Debug.Print("Saved client to database.");
                }
            }
        }

        public static void SaveConnection()
        {
            Debug.Print($"NHiberControl method SaveConnection called.");
            Connection connection = new Connection();
            connection.idAirportStart = 1;
            connection.idAirportEnd = 2;
            connection.Name = $"{LoadAirportsToList().Single(x => x.id == connection.idAirportStart).name} - {LoadAirportsToList().Single(x => x.id == connection.idAirportEnd).name}";
            connection.distance = 100;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(connection);
                    transaction.Commit();
                    Debug.Print("Saved connection to database.");
                }
            }
        }
        #endregion Save Methods
    }
}
